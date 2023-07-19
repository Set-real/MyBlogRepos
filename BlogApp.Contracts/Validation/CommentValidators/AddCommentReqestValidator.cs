using BlogApp.Contracts.Models.Comments;
using FluentValidation;

namespace BlogApp.Contracts.Validation.CommentValidators
{
    public class AddCommentReqestValidator: AbstractValidator<CommentReqest>
    {
        public AddCommentReqestValidator()
        {
            RuleFor(x => x.CommentContext).NotEmpty();
        }
    }
}
