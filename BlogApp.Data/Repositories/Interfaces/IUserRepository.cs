using BlogApp.Data.Queries;
using BlogApp.Model;

namespace BlogApp.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task CreateUser(User user);
        public Task UpdateUser(User user, UpdateUserQuery query);
        public Task DeleteUser(User user);
        public Task<User[]> GetAllUsers();
        public Task<User> GetUserById(Guid id);
        public Task<User> GetUserByLogin(string login);
    }
}
