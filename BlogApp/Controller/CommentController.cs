using AutoMapper;
using BlogApp.Contracts.Models.Comments;
using BlogApp.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BlogApp.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController
    {
        private IMapper _mapper;
        private ICommentRepository _comment;
        private IUserRepository _user;
        
        public CommentController(IMapper mapper, ICommentRepository comment, IUserRepository user)
        {
            _mapper = mapper;
            _comment = comment;
            _user = user;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> CreateComment(AddCommentReqest reqest)
        {
            var user 
        }
    }
}
