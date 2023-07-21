using BlogApp.Contracts.Models.Roles;
using FluentValidation;

namespace BlogApp.Contracts.Validation.RoleValidators
{
    public class AddRolleReqestValidator: AbstractValidator<RoleReqest>
    {
        public AddRolleReqestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
