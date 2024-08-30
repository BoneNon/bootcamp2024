using Application.Contracts.Persistence;
using Application.Features.BlogPost.Commands.DeleteBlogPost;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPost.Commands.DeleteBlogPost
{
    public class DeleteBlogPostHandler : IRequestHandler<DeleteBlogPostCommand, BlogPostDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public DeleteBlogPostHandler(IBlogPostRepository blogPostRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task<BlogPostDto> Handle(DeleteBlogPostCommand request, CancellationToken cancellationToken)
        {
            var blogPost = mapper.Map<Domain.Entities.BlogPost>(request.Id);

            var result = await blogPostRepository.DeleteAsync(request.Id);

            return mapper.Map<BlogPostDto>(result);
        }
    }
}
