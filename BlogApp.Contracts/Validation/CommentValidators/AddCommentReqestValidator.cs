using BlogApp.Contracts.Models.Comments;
using FluentValidation;

namespace BlogApp.Contracts.Validation.CommentValidators
{
    public class AddCommentReqestValidator: AbstractValidator<AddCommentReqest>
    {
        public AddCommentReqestValidator()
        {
            RuleFor(x => x.CommentContext).NotEmpty();
        }
    }
}
