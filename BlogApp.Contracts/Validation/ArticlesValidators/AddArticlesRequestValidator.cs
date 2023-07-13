﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Validation.ArticlesValidators
{
    public class AddArticlesRequestValidator: AbstractValidator<>
    {
        RullFor(x => x.Name)
    }
}
