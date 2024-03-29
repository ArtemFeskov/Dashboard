﻿using Dashboard.Data.Data.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Data.Validation
{

    public class RegisterUserValidation : AbstractValidator<RegisterUserVM>
    {
        public RegisterUserValidation()
        {
            RuleFor(r => r.Emeil).NotEmpty().EmailAddress();
            RuleFor(r => r.Password).NotEmpty().MinimumLength(6).MaximumLength(30);
            RuleFor(r => r.ConfirmPassword).NotEmpty().MinimumLength(6).MaximumLength(30);
        }
    }
}
