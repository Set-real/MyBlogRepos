using BlogApp.Data.Queries;
using BlogApp.Model;
using BlogApp.Model.DataModel;

namespace BlogApp.Data.Repositories
{
    public interface ICommentRepository
    {
        public Task CreateComment(Comment comment, User user, Article article);
        public Task UpdateComment(Comment comment, UpdateArticleQuery query);
        public Task DeleteComment(Comment comment);
        public Task<Comment[]> GetAllComments();
        public Task<Comment> GetCommentById(Guid id);
    }
}
