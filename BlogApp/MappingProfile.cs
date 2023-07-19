using AutoMapper;
using BlogApp.Contracts.Models.Articles;
using BlogApp.Contracts.Models.Comments;
using BlogApp.Contracts.Models.Tegs;
using BlogApp.Contracts.Models.Users;
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
    }
}