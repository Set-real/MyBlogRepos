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
using BlogApp.Model;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Formats.Tar;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddScoped<IValidator<AddUserRequest>, AddUserRequestValidator>();
builder.Services.AddScoped<IValidator<EditUserRequest>, EditUserRequestValidator>();
builder.Services.AddScoped<IValidator<AddArticlesReqest>, AddArticlesRequestValidator>();
builder.Services.AddScoped<IValidator<EditArticleRequest>, EditArticlesRequestValidator>();
builder.Services.AddScoped<IValidator<AddCommentReqest>, AddCommentReqestValidator>();
builder.Services.AddScoped<IValidator<EditCommentReqest>, EditCommentReqestValidator>();
builder.Services.AddScoped<IValidator<AddTegRequest>, AddTegRequestValidator>();
builder.Services.AddScoped<IValidator<EditTegRequest>, EditTegRequestValidator>();

// Регистрирую строку подключения
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogContext>(option => option.UseSqlServer(connectionString), ServiceLifetime.Singleton);

builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
