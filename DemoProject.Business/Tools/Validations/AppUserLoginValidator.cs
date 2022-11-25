using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.DTO.Concrete.AppUser;
using FluentValidation;
using FluentValidation.Validators;

namespace DemoProject.Business.Tools.Validations
{
    class AppUserLoginValidator:AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.Password).NotEmpty().WithMessage("password cannot be blank");
            RuleFor(I => I.UserName).NotEmpty().WithMessage("username cannot be blank");
        }
    }
}
