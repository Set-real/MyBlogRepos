using BlogApp.Data.Queries;
using BlogApp.Model;
using BlogApp.Model.DataModel;

namespace BlogApp.Data.Repositories
{
    public interface IArticlRepository
    {
        public Task CreateArticle(Article article, User user);
        public Task UpdateArticle(Task<Article> article, Task<User>user, UpdateArticleQuery query);
        public Task DeleteArticle(Article article);
        public Task<Article> GetArticleById(Guid id);
        public Task<Article[]> GetArticles();
    }
}
