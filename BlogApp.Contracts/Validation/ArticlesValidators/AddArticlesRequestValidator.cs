using BlogApp.Contracts.Models.Articles;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Validation.ArticlesValidators
{
    public class AddArticlesRequestValidator: AbstractValidator<AddArticlesReqest>
    {
        public AddArticlesRequestValidator() 
        {
            RuleFor(x => x.ArticleContext).NotEmpty();
            RuleFor(x => x.ArticlesName).NotEmpty().MaximumLength(50);
        }
    }
}
