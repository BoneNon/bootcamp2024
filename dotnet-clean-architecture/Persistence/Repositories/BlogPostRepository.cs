using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories {
    public class BlogPostRepository : IBlogPostRepository {
        private readonly ApplicationDbContext dbContext;

        public BlogPostRepository(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<BlogPost> CreateAsync(BlogPost blogpost) {
            await dbContext.BlogPosts.AddAsync(blogpost);
            await dbContext.SaveChangesAsync();

            return blogpost;
        }

        public async Task<List<BlogPost>> GetAllBlogPosts() {
            var blogpost = await dbContext.BlogPosts.AsNoTracking().Include(i => i.Categories).ToListAsync();
            return blogpost;
        }

        public async Task<BlogPost> GetByIdAsync(Guid id)
        {
            var blogpost = await dbContext.BlogPosts.Include(i => i.Categories).Where(w => w.Id == id).FirstOrDefaultAsync();
            if (blogpost == null)
            {
                return null;
            }

            return blogpost;
        }

        public async Task<BlogPost> DeleteAsync(Guid id)
        {
            var blogpost = await dbContext.BlogPosts.Where(w => w.Id == id).FirstOrDefaultAsync();
            if (blogpost == null)
            {
                return null;
            }

            dbContext.BlogPosts.Remove(blogpost);
            await dbContext.SaveChangesAsync();

            return blogpost;
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogpost)
        {
            var blogpostDb = await dbContext.BlogPosts.Include(i => i.Categories).Where(w => w.Id == blogpost.Id).FirstOrDefaultAsync();

            if (blogpostDb == null)
            {
                return null;
            }

            blogpostDb.Categories.Clear();

            blogpostDb.Title = blogpost.Title;
            blogpostDb.ShortDescription = blogpost.ShortDescription;
            blogpostDb.Content = blogpost.Content;
            blogpostDb.FeaturedImageUrl = blogpost.FeaturedImageUrl;
            blogpostDb.UrlHandle = blogpost.UrlHandle;
            blogpostDb.PublishedDate = blogpost.PublishedDate;
            blogpostDb.Author = blogpost.Author;
            blogpostDb.IsVisible = blogpost.IsVisible;
            blogpostDb.Categories = blogpost.Categories;



            await dbContext.SaveChangesAsync();

            return blogpostDb;
        }
    }
}
