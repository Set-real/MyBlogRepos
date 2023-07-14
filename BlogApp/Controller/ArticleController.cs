using AutoMapper;
using BlogApp.Contracts.Models.Articles;
using BlogApp.Contracts.Models.Users;
using BlogApp.Data.Queries;
using BlogApp.Data.Repositories;
using BlogApp.Model;
using BlogApp.Model.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controller
{
    [ApiController]
    [Route("[ArticleController]")]
    public class ArticleController : ControllerBase
    {
        public IUserRepository _user;
        public IArticlRepository _articl;
        public IMapper _mapper;
        public ArticleController(IArticlRepository articl, IUserRepository user, IMapper mapper)
        {
            _articl = articl;
            _mapper = mapper;
            _user = user;
        }
        /// <summary>
        /// Метод для получения всех статей
        /// </summary>
        /// <returns>StatusCode(200, resp)</returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _articl.GetArticles();

            var resp = new GetArticlesResponse
            {
                ArticleAmont = articles.Length,
                articleViews = _mapper.Map<Article[], ArticleView[]>(articles)
            };

            return StatusCode(200, resp);
        }
        /// <summary>
        /// Метод для добавления новой статьи
        /// </summary>
        /// <param name="reqest"></param>
        /// <param name="userMod"></param>
        /// <returns>StatusCode(200, newArticle)</returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateArticle(AddArticlesReqest reqest)
        {
            //Проверяю пользователя на null
            var user = await _user.GetUserById(reqest.Id);
            if (user == null)
                return StatusCode(400, $"Пользователь {user.FirstName} не найден!");

            // Добавляю статью
            var newArticle = _mapper.Map<AddArticlesReqest, Article>(reqest);
            await _articl.CreateArticle(newArticle, user);

            return StatusCode(200, newArticle);
        }
        /// <summary>
        /// Находим статью по Id
        /// </summary>
        /// <param name="article"></param>
        /// <returns>StatusCode(200, verifiableArticle)</returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetsArticleById(AddArticlesReqest article)
        {
            var verifiableArticle = await _articl.GetArticleById(article.Id);

            return StatusCode(200, verifiableArticle);
        }
        [HttpPatch]
        [Route("Id")]
        public async Task<IActionResult> UpdateArticle(
            [FromRoute] Guid Id,
            [FromBody] EditArticleRequest request
            )
        {
            var user = _user.GetUserById(Id);
            if (user == null)
                return StatusCode(400, "Пользователь не найден!");

            var article = _articl.GetArticleById(Id);
            if (article == null)
                return StatusCode(400, "Статья не найдена");

            var updateArticle = _articl.UpdateArticle(
                article,
                user,
                new UpdateArticleQuery(request.NewArticleName, request.NewArticleContext));

            return StatusCode(200, updateArticle);
        }
    }
}
