using BlogApp.Data.Context;
using BlogApp.Data.Queries;
using BlogApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public BlogContext _context;
        public UserRepository(BlogContext context)
        {
            context = _context;
        }
        public async Task DeleteUser(User user)
        {
            var entry = _context.Entry(user);
            if(entry.State == EntityState.Detached)
                _context.Remove(entry);

            await _context.SaveChangesAsync();
        }

        public Task<User> GetAllUsers()
        {
            
        }

        public Task<User> GetUserById(Guid id)
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

        Task<User[]> IUserRepository.GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
