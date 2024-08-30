using Application.Features.BlogPost.Commands.DeleteBlogPost;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence {
    public interface IBlogPostRepository {
        Task<BlogPost> CreateAsync(BlogPost blogPost);
        Task<BlogPost> DeleteAsync(Guid id);
        Task<BlogPost> UpdateAsync(BlogPost blogPost);
        Task<BlogPost> GetByIdAsync(Guid id);
        Task<List<BlogPost>> GetAllBlogPosts();
    }
}
