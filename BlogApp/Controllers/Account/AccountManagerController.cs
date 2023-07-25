using AutoMapper;
using BlogApp.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers.Account
{
    [ApiController]
    [Route("[controller]")]
    public class AccountManagerController: Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private IMapper _mapper;
        public AccountManagerController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        [Route("Login")]
        [HttpGet]
        public IActionResult Login() 
        {
            return View("Login");
        }
    }
}
