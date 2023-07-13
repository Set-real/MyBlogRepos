using BlogApp.Data.Queries;
using BlogApp.Model;
using BlogApp.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Repositories
{
    public interface IArticlRepository
    {
        public Task CreateArticle(Article article, User user);
        public Task UpdateArticle(Article article, User user, UpdateCommentQuery query);
        public Task DeleteArticle(Article article);
        public Task<Article> GetArticleById(Guid id);
        public Task<Article[]> GetArticles();
    }
}
