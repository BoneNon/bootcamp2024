using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPost.Queries.GetAllBlogPosts {
    public class GetAllBlogPostsHandler : IRequestHandler<GetAllBlogPostsQuery, List<BlogPostDto>> {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IMapper mapper;

        public GetAllBlogPostsHandler(IBlogPostRepository blogPostRepository, IMapper mapper) {
            this.blogPostRepository = blogPostRepository;
            this.mapper = mapper;
        }

        public async Task<List<BlogPostDto>> Handle(GetAllBlogPostsQuery request, CancellationToken cancellationToken) {
            var blogposts = await blogPostRepository.GetAllBlogPosts();

            return mapper.Map<List<BlogPostDto>>(blogposts);
            
        }
    }
}
