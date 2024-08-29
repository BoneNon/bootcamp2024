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
    public class CategoryRepository : ICategoryRepository {
        protected readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category) {
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteAsync(Guid id) {
            var category = await dbContext.Categories.Where(w => w.Id == id).FirstOrDefaultAsync();
            if (category == null) {
                return null;
            }

            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<List<Category>> GetAllCategories() {
            return await dbContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id) {
            return await dbContext.Categories.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Category> UpdateAsync(Category category) {
            var categoryDb = await dbContext.Categories.Where(w => w.Id == category.Id).FirstOrDefaultAsync();

            if (categoryDb == null) {
                return null;
            }

            categoryDb.Name = category.Name;
            categoryDb.UrlHandle = category.UrlHandle;

            await dbContext.SaveChangesAsync();

            return categoryDb;
        }
    }
}
