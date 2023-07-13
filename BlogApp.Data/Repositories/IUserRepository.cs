using BlogApp.Data.Queries;
using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Repositories
{
    public interface IUserRepository
    {
        public Task RegistUser(User user);
        public Task UpdateUser(User user, UpdateUserQuery query);
        public Task DeleteUser(User user);
        public Task<User[]> GetAllUsers();
        public Task<User> GetUserById(Guid id);
    }
}
