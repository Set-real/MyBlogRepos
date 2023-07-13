using BlogApp.Contracts.Models.Comments;
using FluentValidation;

namespace BlogApp.Contracts.Validation.CommentValidators
{
    public class EditCommentReqestValidator: AbstractValidator<EditCommentReqest>
    {
        public EditCommentReqestValidator()
        {
            RuleFor(x => x.NewContent).NotEmpty();
        }
    }
}
