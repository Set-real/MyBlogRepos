using AutoMapper;
using BlogApp.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controller
{
    [ApiController]
    [Route("[UserController]")]
    public class UserController: ControllerBase
    {    
        IUserRepository _user;
        IMapper _mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            _user = repository;
            _mapper = mapper;
        }

    }
}
