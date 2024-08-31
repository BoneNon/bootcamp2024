using Application.Contracts.Persistence;
using Application.Features.BlogPost.Queries.GetBlogPostById;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPost.Queries.GetBlogPostById
{
    public class GetBlogPostByIdHandler : IRequestHandler<GetBlogPostByIdQuery, BlogPostDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public GetBlogPostByIdHandler(IBlogPostRepository blogPostRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
        this.blogPostRepository = blogPostRepository;
        this.mapper = mapper;
        this.categoryRepository = categoryRepository;
        }

        public async Task<BlogPostDto> Handle(GetBlogPostByIdQuery request, CancellationToken cancellationToken)
        {
            //var blogPost = mapper.Map<Domain.Entities.BlogPost>(request.Id);

            var result = await blogPostRepository.GetByIdAsync(request.Id);

            return mapper.Map<BlogPostDto>(result);
        }
    }
    
}
