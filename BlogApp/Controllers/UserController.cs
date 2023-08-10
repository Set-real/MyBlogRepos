using AutoMapper;
using BlogApp.Contracts.Models.Users;
using BlogApp.Data.Model.ViewModels;
using BlogApp.Data.Queries;
using BlogApp.Data.Repositories;
using BlogApp.Handlers;
using BlogApp.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Security.Claims;

namespace BlogApp.Controllers
{
    [ExeptionHandler]
    [ApiController]
    [Route("[controller]")]
    public class UserController: Controller
    {    
        IUserRepository _user;
        IMapper _mapper;
        private readonly UserManager<UserRequest> _userManager;
        private readonly SignInManager<UserRequest> _signInManager;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            _user = repository;
            _mapper = mapper;
        }
        /// <summary>
        /// Методя для получения всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _user.GetAllUsers();

            var resp = new GetUserResponse
            {
                UserAmount = user.Length,
                UserView = _mapper.Map<User[], UserViewModel[]>(user)
            };

            return StatusCode(200, resp);
        }
        /// <summary>
        /// Метод для поиска пользователя по Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUserById(UserRequest request)
        {
            var user = _user.GetUserById(request.Id);
            if (user == null)
            {
                return StatusCode(400, "Такой пользователь не найден!");
            }
            else
            {
                return StatusCode(200, user);
            }
        }
        /// <summary>
        /// Метод для регистрации нового пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
            return View("AddTeg");
        }
        // <summary>
        /// Метод для обновления пользователя
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("")]
        public async Task<IActionResult> UpdateUser(
            [FromRoute] Guid Id,
            [FromBody] EditUserRequest request)
        {
            var user = _user.GetUserById(request.Id);
            if (user == null)
                return StatusCode(400, "Такой пользователь не существует!");

            var updateUser = _user.UpdateUser(
                await user,
                new UpdateUserQuery(
                    request.NewFirstName,
                    request.NewLastName,
                    request.NewEmail,
                    request.NewPassword,
                    request.NewLogin));

            return StatusCode(200, updateUser);
        }
        /// <summary>
        /// Метод для удаления пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeliteUser(UserRequest request)
        {
            var user = await _user.GetUserById(request.Id);
            if (user == null)
                return StatusCode(400, "Пользователь не найден!");

            var delUser = _user.DeleteUser(user);
            
            return StatusCode(200, delUser);
        }
        /// <summary>
        /// Метод для аутентификации пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="AuthenticationException"></exception>
        [HttpPost]
        [Route("Authenticate")]
        public async Task<Contracts.Models.Users.UserViewModel> Authenticate(UserRequest request, string login, string password)
        {
            if (!string.IsNullOrEmpty(request.Login) ||
                (!string.IsNullOrEmpty(request.Password)
                && !string.IsNullOrEmpty(request.Email)))
                throw new ArgumentNullException("Введенные данные некорректны");

            var user = _user.GetUserByLogin(login);
            if (user == null)
                throw new AuthenticationException("Неверный логин");

            if (request.Password != password)
                throw new AuthenticationException("Неверный пароль");

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, request.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, request.Role.Name)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "AddCookies",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return _mapper.Map<Contracts.Models.Users.UserViewModel>(user);
        }
        [Route("Logout")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);

                var result = await _signInManager.PasswordSignInAsync(user.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View("Views/Home/Index.cshtml");
        }
    }
}
