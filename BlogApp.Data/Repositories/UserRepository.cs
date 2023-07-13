using BlogApp.Data.Queries;
using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User[]> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task RegistUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User user, UpdateUserQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
