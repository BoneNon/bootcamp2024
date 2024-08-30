using Application.Contracts.Persistence;
using Application.Features.BlogPost.Commands.CreateBlogPost;
using Application.Features.BlogPost.Commands.UpdateBlogPost;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPost.Commands.UpdateBlogPost
{
    public class UpdateBlogPostHandler : IRequestHandler<UpdateBlogPostCommand, BlogPostDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public UpdateBlogPostHandler(IBlogPostRepository blogPostRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task<BlogPostDto> Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
        {
            var blogPostUpdateModel = mapper.Map<Domain.Entities.BlogPost>(request.Request);
            blogPostUpdateModel.Id = request.Id;

            foreach (var categoryId in request.Request.Categories)
            {
                var category = await categoryRepository.GetByIdAsync(categoryId);
                if (category is not null)
                {
                    blogPostUpdateModel.Categories.Add(category);
                }
            }

            var result = await blogPostRepository.CreateAsync(blogPostUpdateModel);

            return mapper.Map<BlogPostDto>(result);
        }


    }

    
}
