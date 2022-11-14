using Test.Data.Entities;
using TestWebAPI.Models.Requests;

namespace TestWebAPI.Services.Interfaces
{
    public interface IUsersService
    {
        Task<User?> LoginUser(string username, string password);
        Task<IEnumerable<User>> Get();
        public void  CreateUser(User user);
        public void UpdateUser(Guid id, User user);
        public void DeleteUser(Guid id, User user);
        Task<User> GetUsersById(Guid id);
    }
}
