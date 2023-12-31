﻿using BlogApp.Data.Queries;
using BlogApp.Model;
using BlogApp.Model.DataModel;

namespace BlogApp.Data.Repositories.Interfaces
{
    public interface IArticlRepository
    {
        public Task CreateArticle(Article article, User user);
        public Task UpdateArticle(Article article, User user, UpdateArticleQuery query);
        public Task DeleteArticle(Article article);
        public Task<Article> GetArticleById(Guid id);
        public Task<Article[]> GetArticles();
    }
}
