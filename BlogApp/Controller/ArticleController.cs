using AutoMapper;
using BlogApp.Contracts.Models.Articles;
using BlogApp.Data.Repositories;
using BlogApp.Model.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controller
{
    [ApiController]
    [Route("[ArticleController]")]
    public class ArticleController: ControllerBase
    {
        public IArticlRepository _articl;
        public IMapper _mapper;
        public ArticleController(IArticlRepository articl, IMapper mapper)
        {
            _articl = articl;
            _mapper = mapper;
        }
        /// <summary>
        /// Метод для получения всех статей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _articl.GetArticles();

            var resp = new GetArticlesResponse
            {
                ArticleAmont = articles.Length,
                articleViews = _mapper.Map<Article[], ArticleView[]>(articles)
            };

            return StatusCode(200, resp);
        }
    }
}
