using BlogApp.Data.Context;
using BlogApp.Data.Queries;
using BlogApp.Data.Repositories.Interfaces;
using BlogApp.Model.DataModel;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Repositories
{
    /// <summary>
    /// Класс-репозиторий для работы с тегом
    /// </summary>
    public class TegRepository : ItegRepository
    {
        public BlogContext _context;
        public TegRepository(BlogContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Метод для создания тега
        /// </summary>
        /// <param name="teg"></param>
        /// <returns></returns>
        public async Task CreateTeg(Teg teg)
        {
            var entry = _context.Entry(teg);
            if(entry.State == EntityState.Detached)
                _context.AddAsync(entry);

            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Метод для удаления тега
        /// </summary>
        /// <param name="teg"></param>
        /// <returns></returns>
        public async Task DeleteTeg(Teg teg)
        {
            var entry = _context.Entry(teg);
            if(entry.State == EntityState.Detached)
                _context.Remove(entry);

            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Метод для получения тега по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Teg> GetTegById(Guid id)
        {
            return await _context.Tegs
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Метод для получения всех тегов
        /// </summary>
        /// <returns></returns>
        public async Task<Teg[]> GetTegArray()
        {
            return await _context.Tegs
                .ToArrayAsync();
        }
        /// <summary>
        /// Метод для изменения тегаd
        /// </summary>
        /// <param name="teg"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task UpdateTeg(Teg teg, UpdateTegQuery query)
        {
            if(!string.IsNullOrEmpty(query.NewTeg))
                teg.Value = query.NewTeg;

            var entry = _context.Entry(teg);
            if(entry.State == EntityState.Detached)
                _context.Update(entry);

            await _context.SaveChangesAsync();
        }       
    }
}
