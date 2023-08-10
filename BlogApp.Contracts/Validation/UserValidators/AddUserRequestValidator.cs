using BlogApp.Contracts.Models.Users;
using FluentValidation;

namespace BlogApp.Contracts.Validation.UserValidators
{
    public class AddUserRequestValidator: AbstractValidator<UserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Login).NotEmpty().MaximumLength(30);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(100);
        }
    }
}
