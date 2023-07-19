using BlogApp.Contracts.Models.Tegs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Validation.TegValidators
{
    public class EditTegRequestValidator: AbstractValidator<EditTegRequest>
    {
        public EditTegRequestValidator()
        {
            RuleFor(x => x.NewValue).NotEmpty().MaximumLength(100);
        }
    }
}
