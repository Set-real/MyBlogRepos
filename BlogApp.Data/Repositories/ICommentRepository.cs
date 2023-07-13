using BlogApp.Data.Queries;
using BlogApp.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Repositories
{
    public interface ICommentRepository
    {
        public Task CreateComment(Comment comment);
        public Task UpdateComment(Comment comment, UpdateCommentQuery query);
        public Task DeleteComment(Comment comment);
        public Task<Comment> GetAllComments();
        public Task<Comment> GetCommentById(Guid id);
    }
}
