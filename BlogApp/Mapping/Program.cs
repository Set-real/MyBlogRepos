using AutoMapper;
using BlogApp.Contracts.Models.Articles;
using BlogApp.Contracts.Models.Comments;
using BlogApp.Contracts.Models.Tegs;
using BlogApp.Contracts.Models.Users;
using BlogApp.Contracts.Validation.ArticlesValidators;
using BlogApp.Contracts.Validation.CommentValidators;
using BlogApp.Contracts.Validation.TegValidators;
using BlogApp.Contracts.Validation.UserValidators;
using BlogApp.Data.Context;
using BlogApp.Data.Repositories;
using BlogApp.Middlewares;
using BlogApp.Model;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Formats.Tar;

var builder = WebApplication.CreateBuilder(args);

// Регистрирую строку подключения
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogContext>(option => option.UseSqlServer(connectionString), ServiceLifetime.Singleton);

// Добавляю маппер
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Регистрирую сервисы репозитории для взаимодействия с БД
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ItegRepository, TegRepository>();
builder.Services.AddSingleton<ICommentRepository, CommentRepository>();
builder.Services.AddSingleton<IArticlRepository, ArticleRepository>();

// Регистрация валидиции
builder.Services.AddScoped<IValidator<UserRequest>, AddUserRequestValidator>();
builder.Services.AddScoped<IValidator<EditUserRequest>, EditUserRequestValidator>();
builder.Services.AddScoped<IValidator<ArticlesReqest>, AddArticlesRequestValidator>();
builder.Services.AddScoped<IValidator<EditArticleRequest>, EditArticlesRequestValidator>();
builder.Services.AddScoped<IValidator<CommentReqest>, AddCommentReqestValidator>();
builder.Services.AddScoped<IValidator<EditCommentReqest>, EditCommentReqestValidator>();
builder.Services.AddScoped<IValidator<TegRequest>, AddTegRequestValidator>();
builder.Services.AddScoped<IValidator<EditTegRequest>, EditTegRequestValidator>();

// Подключаю сваггер
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Если пользователь не проходит аутентификацию, то получает ошибкув
builder.Services.AddAuthentication(options => options.DefaultScheme = "Cookies")
    .AddCookie("Cookies", options =>
    {
        options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
        {
            OnRedirectToLogin = redirectContext =>
            {
                redirectContext.HttpContext.Response.StatusCode = 401;
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.UseStaticFiles();

app.UseRouting();

// Подключаю аутентификацию и авторизацию
app.UseAuthentication();
app.UseAuthorization();

app.UseLogMiddleware();

//app.MapRazorPages();

//app.Run();
