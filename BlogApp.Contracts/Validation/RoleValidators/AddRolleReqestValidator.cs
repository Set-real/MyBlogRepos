using BlogApp.Contracts.Models.Roles;
using FluentValidation;

namespace BlogApp.Contracts.Validation.RoleValidators
{
    public class AddRolleReqestValidator: AbstractValidator<RoleReqest>
    {
        public AddRolleReqestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Must(BeSupported);
        }

        /// <summary>
        /// Проверка на соответствие ролям
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        private bool BeSupported(string roleName)
        {
            return RoleValues.Rols.Any(e => e ==  roleName);
        }
    }
}
