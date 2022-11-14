using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Models.Requests;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly TestContext _categoryContext;
        public CategoryService(TestContext categoryContext)
        {
            _categoryContext = categoryContext;
        }
        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category?> Get(int id)
        {
            return await _categoryContext.Categories.FirstOrDefaultAsync(b => b.CategoryId == id);
        }

        public void CreateCategory (Category category)
        {
            _categoryContext.Categories.Add(category);
            _categoryContext.SaveChanges(); 
        }
 
        public void UpdateCategory ( Category category)
        {
            var categoryUpdate = _categoryContext.Categories.Where(c => c.CategoryId == category.CategoryId).FirstOrDefault();
            categoryUpdate.CategoryId = category.CategoryId;
            categoryUpdate.Name = category.Name;
            _categoryContext.SaveChanges();
        }

        public void DeleteCategory(int id, Category category)
        {
            var categoryUpdate = _categoryContext.Categories.Where(c => c.CategoryId == category.CategoryId).FirstOrDefault();
            _categoryContext.Categories.Remove(category);
            _categoryContext.SaveChanges();
        }
    }
}
