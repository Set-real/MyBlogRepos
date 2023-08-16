using AutoMapper;
using BlogApp.Contracts.Models.Articles;
using BlogApp.Contracts.Models.Comments;
using BlogApp.Contracts.Models.Tegs;
using BlogApp.Contracts.Models.Users;
using BlogApp.Data.Model.ViewModels;
using BlogApp.Model;
using BlogApp.Model.DataModel;

internal class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<UserRequest, User>().ReverseMap();
        CreateMap<User, UserRequest>().ReverseMap();
        CreateMap<TegRequest, Teg>().ReverseMap();
        CreateMap<ArticlesReqest, Article>().ReverseMap();
        CreateMap<CommentReqest, Comment>()
            .ForMember(x => x.Content, opt => opt.MapFrom(c => c.CommentContext)).ReverseMap();

        CreateMap<User, UserViewModel>().ReverseMap();
        CreateMap<Comment, CommentViewModel>().ReverseMap();
        CreateMap<Article, ArticleViewModel>().ReverseMap();
        CreateMap<Teg, TegViewModel>().ReverseMap();

        CreateMap<RegisterViewModel, UserRequest>()
            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.EmailReg))
            .ForMember(x => x.Password, opt => opt.MapFrom(x => x.PasswordReg)).ReverseMap();
        CreateMap<LoginViewModel, UserRequest>().ReverseMap();
        CreateMap<TegViewModel, TegRequest>().ReverseMap();
    }
}