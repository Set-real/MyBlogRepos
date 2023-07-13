using BlogApp.Contracts.Models.Tegs;
using FluentValidation;

namespace BlogApp.Contracts.Validation.TegValidators
{
    public class AddTegRequestValidator: AbstractValidator<AddTegRequest>
    {
        public AddTegRequestValidator()
        {
            RuleFor(x => x.Value).NotEmpty().MaximumLength(100);
        }
    }
}
