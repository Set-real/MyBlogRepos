﻿using AutoMapper;
using BlogApp.Contracts.Models.Users;
using BlogApp.Data.Queries;
using BlogApp.Data.Repositories;
using BlogApp.Model;
using Microsoft.AspNetCore.Mvc;
using System.Runtime;
using System.Security.Authentication;

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
                UserView = _mapper.Map<User[], UserView[]>(user)
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
        public async Task<IActionResult> GetUserById(AddUserRequest request)
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
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> RegistUser(AddUserRequest request)
        {
            var user = _user.GetUserById(request.Id);
            if (user != null)
                return StatusCode(400, "Такой пользователь уже существует!");

            var newUser = _mapper.Map<AddUserRequest, User>(request);
            await _user.RegistUser(newUser);

            return StatusCode(200, newUser);
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
        public async Task<IActionResult> DeliteUser(AddUserRequest request)
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
        public UserView Authenticate(AddUserRequest request, string login, string password)
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

            return _mapper.Map<UserView>(user);
        }
    }
}
