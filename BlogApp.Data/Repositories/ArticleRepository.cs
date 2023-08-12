using BlogApp.Data.Context;
using BlogApp.Data.Queries;
using BlogApp.Data.Repositories.Interfaces;
using BlogApp.Model;
using BlogApp.Model.DataModel;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Repositories
{
    /// <summary>
    /// Класс-репозиторий для статьи
    /// </summary>
    public class ArticleRepository : IArticlRepository
    {
        public BlogContext _context;
        public ArticleRepository(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод для создания статьи
        /// </summary>
        /// <param name="article"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task CreateArticle(Article article, User user)
        {
            article.User_Id = user.Id;

            var entry = _context.Entry(article);
            if(entry.State == EntityState.Detached)
                _context.AddAsync(article);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Метод для удаления статьи
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public async Task DeleteArticle(Article article)
        {
            var entry = _context.Entry(article);
            if (entry.State == EntityState.Detached)
                _context.Remove(article);

            await _context.SaveChangesAsync();  
        }
        /// <summary>
        /// Метод для получения статьи по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Article> GetArticleById(Guid id)
        {
            return await _context.Articles
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Метод для получения всех статей
        /// </summary>
        /// <returns></returns>
        public async Task<Article[]> GetArticles()
        {
            return await _context.Articles
                .ToArrayAsync();
        }

        /// <summary>
        /// Метод для изменения статьи
        /// </summary>
        /// <param name="article"></param>
        /// <param name="user"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task UpdateArticle(Article article, User user, UpdateArticleQuery query)
        {
            article.User_Id = user.Id;

            if(!string.IsNullOrEmpty(query.NewContent))
                article.Content = query.NewContent;
            if(!string.IsNullOrEmpty(query.NewName)) 
                article.Name = query.NewName;

            var entry = _context.Entry(article);
            if( entry.State == EntityState.Detached)
                _context.Update(article);

            await _context.SaveChangesAsync();
        }
    }
}
