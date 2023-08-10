using AutoMapper;
using BlogApp.Contracts.Models.Users;
using BlogApp.Data.Model.ViewModels;
using BlogApp.Data.Repositories;
using BlogApp.View.Pages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers.Account
{
    public class RegisterController : Controller
    {
        private readonly UserManager<UserRequest> _userManager;
        private readonly SignInManager<UserRequest> _signInManager;
        private readonly IMapper _mapper;
        public RegisterController(UserManager<UserRequest> userManager, SignInManager<UserRequest> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserRequest>(model);

                var result = await _userManager.CreateAsync(user, model.PasswordReg);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View("HomePages");
        }
    }
}

