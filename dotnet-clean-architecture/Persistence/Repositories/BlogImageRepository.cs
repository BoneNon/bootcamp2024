using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories {
    public class BlogImageRepository : IBlogImageRepository {
        private readonly ApplicationDbContext dbContext;

        public BlogImageRepository(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<BlogImage> SaveImage(BlogImage blogImage) {
            await dbContext.BlogImages.AddAsync(blogImage);
            await dbContext.SaveChangesAsync();

            return blogImage;
        }
    }
}
