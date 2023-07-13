using BlogApp.Data.Context;
using BlogApp.Data.Queries;
using BlogApp.Model;
using BlogApp.Model.DataModel;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Repositories
{
    /// <summary>
    /// Класс-репозиторий для работы с комментарием
    /// </summary>
    public class CommentRepository : ICommentRepository
    {
        public BlogContext _context;
        public CommentRepository(BlogContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Метод для создания комментария
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="user"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        public async Task CreateComment(Comment comment, User user, Article article)
        {
            comment.User_Id = user.Id;
            comment.Article_Id = article.Id;

            var entry = _context.Entry(comment);
            if(entry.State == EntityState.Detached)
                _context.AddAsync(comment);

            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Метод для удаления комментария
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task DeleteComment(Comment comment)
        {
            var entry = _context.Entry(comment);
            if (entry.State == EntityState.Detached)
                _context.Remove(entry);

            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Метод для получения всех комментариев
        /// </summary>
        /// <returns></returns>
        public async Task<Comment[]> GetAllComments()
        {
            return await _context.Comments.ToArrayAsync();
        }
        /// <summary>
        /// Метод для получения комментария по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Comment> GetCommentById(Guid id)
        {
            return await _context.Comments
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Метод для изменения комментария
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task UpdateComment(Comment comment, UpdateArticleQuery query)
        {
           if(!string.IsNullOrEmpty(query.NewContent))
                comment.Content = query.NewContent;

            var entry = _context.Entry(comment);
            if( entry.State == EntityState.Detached)
                _context.Update(entry);

            await _context.SaveChangesAsync();
        }
    }
}
