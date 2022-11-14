using Test.Data.Entities;
using TestWebAPI.Models.Requests;

namespace TestWebAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category?> Get(int id);
        Task<IEnumerable<Category>> Get();
        public void CreateCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(int id, Category category);
    }
}
