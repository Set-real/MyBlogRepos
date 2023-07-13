using AutoMapper;
using BlogApp.Data.Context;
using BlogApp.Data.Repositories;
using FluentValidation;
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

// Регистрирую строку подключения
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogContext>(option => option.UseSqlServer(connectionString), ServiceLifetime.Singleton);



builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
