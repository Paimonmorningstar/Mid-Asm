using Test.Data;
using Test.Data.Entities;
using Microsoft.EntityFrameworkCore;
using TestWebAPI.Services.Interfaces;
using TestWebAPI.Models.Requests;

namespace TestWebAPI.Services.Implements
{
    public class UsersService : IUsersService
    {
        private readonly TestContext _userContext;
        public UsersService(TestContext userContext)
        {
            _userContext = userContext;
        }
        public async Task<User?> LoginUser(string username, string password)
        {
            return await _userContext.Users.SingleOrDefaultAsync(x => x.UserName == username && x.Password == password);
        }
        public async Task<IEnumerable<User>> Get()
        {
            return await _userContext.Users.ToListAsync();
        }

        public void CreateUser(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
        }

        public void UpdateUser(Guid id, User user)
        {
            var UserUpdate = _userContext.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
            UserUpdate.UserId = user.UserId;
            UserUpdate.UserName = user.UserName;
            UserUpdate.Password = user.Password;
            _userContext.SaveChanges();
        }

         public void DeleteUser(Guid id, User user)
        {
            var UserUpdate = _userContext.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
            _userContext.Users.Remove(user);
            _userContext.SaveChanges();
        }

        public async Task<User?> GetUsersById(Guid id)
        {
            return await _userContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
