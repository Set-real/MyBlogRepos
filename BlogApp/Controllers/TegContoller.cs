using AutoMapper;
using BlogApp.Contracts.Models.Tegs;
using BlogApp.Data.Queries;
using BlogApp.Data.Repositories;
using BlogApp.Model.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TegContoller : Controller
    {
        ItegRepository _teg;
        IArticlRepository _articl;
        IMapper _mapper;
        public TegContoller(ItegRepository teg, IArticlRepository articl, IMapper mapper)
        {
            _teg = teg;
            _articl = articl;
            _mapper = mapper;
        }
        /// <summary>
        /// Метод для получения всех тегов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllTegs()
        {
            var teg = await _teg.GetTegArray();

            var resp = new GetTegResponse
            {
                TegAmount = teg.Length,
                TegView = _mapper.Map<Teg[], TegViewModel[]>(teg)
            };

            return StatusCode(200, resp);
        }
        /// <summary>
        /// Метод для получения тега по Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetTegById(TegRequest request)
        {
            var teg = _teg.GetTegById(request.Id);
            if (teg == null)
            {
                return StatusCode(400, "Такого тега не существует!");
            }
            else
            {
                return StatusCode(200, teg);
            }
        }
        /// <summary>
        /// Метод для создания нового тега
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateTeg")]
        public async Task<IActionResult> CreateTeg(TegViewModel model)
        {
            if (ModelState.IsValid)
            {
                var teg = _mapper.Map<Teg>(model);

                var resalt = _teg.CreateTeg(teg);
            }  
            return View(model);
        }
        /// <summary>
        /// Метод для удаления тега
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeliteTeg(TegRequest request)
        {
            var teg = _teg.GetTegById(request.Id);
            if (teg == null)
                return StatusCode(400, "Такой тег не найден!");

            var delTeg = _teg.DeleteTeg(await teg);

            return StatusCode(200, delTeg);
        }
        /// <summary>
        /// Метод для обновления тега
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("")]
        public async Task<IActionResult> UpdateTeg(
            [FromRoute] Guid Id,
            [FromBody] EditTegRequest request)
        {
            var teg = _teg.GetTegById(Id);
            if (teg == null)
                return StatusCode(400, "Такой тег не существует");

            //var article = _articl.GetArticleById(Id);
            //if (article == null)
            //    return StatusCode(400, "Такой статьи не существует!");

            var updateTeg = _teg.UpdateTeg(
                await teg,
                new UpdateTegQuery(request.NewValue));

            return StatusCode(200, updateTeg);
        }
    }
}
