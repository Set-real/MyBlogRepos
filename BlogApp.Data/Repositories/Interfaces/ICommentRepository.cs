using BlogApp.Data.Queries;
using BlogApp.Model;
using BlogApp.Model.DataModel;

namespace BlogApp.Data.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        public Task CreateComment(Comment comment, User user, Article article);
        public Task UpdateComment(Comment comment, UpdateCommentQuery query);
        public Task DeleteComment(Comment comment);
        public Task<Comment[]> GetAllComments();
        public Task<Comment> GetCommentById(Guid id);
    }
}
