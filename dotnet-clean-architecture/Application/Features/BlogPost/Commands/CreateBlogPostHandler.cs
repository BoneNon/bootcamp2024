using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPost.Commands {
    public class CreateBlogPostHandler : IRequestHandler<CreateBlogPostCommand, BlogPostDto> {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public CreateBlogPostHandler(IBlogPostRepository blogPostRepository, IMapper mapper, ICategoryRepository categoryRepository) {
            this.blogPostRepository = blogPostRepository;
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task<BlogPostDto> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken) {
            var blogPost = mapper.Map<Domain.Entities.BlogPost>(request.Request);

            foreach(var categoryId in request.Request.Categories) {
                var category = await categoryRepository.GetByIdAsync(categoryId);
                if (category is not null) {
                    blogPost.Categories.Add(category);
                }
            }

            var result = await blogPostRepository.CreateAsync(blogPost);

            return mapper.Map<BlogPostDto>(result);
        }
    }
}
