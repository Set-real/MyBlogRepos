using BlogApp.Data.Context;
using BlogApp.Data.Queries;
using BlogApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Repositories
{
    /// <summary>
    /// Класс-репозиторий для работы с пользователем
    /// </summary>
    public class UserRepository : IUserRepository
    {
        public BlogContext _context;
        public UserRepository(BlogContext context)
        {
            context = _context;
        }
        /// <summary>
        /// Метод для удаления пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task DeleteUser(User user)
        {
            var entry = _context.Entry(user);
            if(entry.State == EntityState.Detached)
                _context.Remove(entry);

            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Метод для получения всех пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<User[]> GetAllUsers()
        {
            return await _context.Users
                .ToArrayAsync();
        }

        /// <summary>
        /// Метод для получения всех пользователей по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await _context.Users
                .Where(u => u.Login == login)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Метод для регистрации нового пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task RegistUser(User user)
        {
            var entry = _context.Entry(user);
            if(entry.State == EntityState.Detached)
                _context.AddAsync(entry);

            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Метод для обновления пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task UpdateUser(User user, UpdateUserQuery query)
        {
            if(!string.IsNullOrEmpty(query.NewUserFirstName))
                query.NewUserFirstName = user.FirstName;
            if(!string.IsNullOrEmpty(query.NewUserLastName))
                query.NewUserLastName = user.LastName;
            if(!string.IsNullOrEmpty(query.NewEmail))
                query.NewEmail = user.Email;
            if(!string.IsNullOrEmpty(query.NewPassword))
                query.NewPassword = user.Password;
            if(!string.IsNullOrEmpty(query.NewLogin))
                query.NewLogin = user.Login;

            var entry = _context.Entry(user);
            if(entry.State == EntityState.Detached)
                _context.Update(entry);

            await _context.SaveChangesAsync();
        }
    }
}
