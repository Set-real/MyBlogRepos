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
        CreateMap<UserRequest, User>();
        CreateMap<User, UserRequest>();
        CreateMap<TegRequest, Teg>();
        CreateMap<ArticlesReqest, Article>();
        CreateMap<CommentReqest, Comment>()
            .ForMember(x => x.Content, opt => opt.MapFrom(c => c.CommentContext));

        CreateMap<User, UserView>();
        CreateMap<Comment, CommentView>();
        CreateMap<Article, ArticleView>();
        CreateMap<Teg, TegView>();

        CreateMap<RegisterViewModel, UserRequest>()
            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.EmailReg))
            .ForMember(x => x.Password, opt => opt.MapFrom(x => x.PasswordReg));
        CreateMap<LoginViewModel, UserRequest>();
    }
}