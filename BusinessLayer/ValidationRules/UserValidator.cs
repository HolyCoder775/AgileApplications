using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("User Full Name cannot be empty!");
            RuleFor(x => x.FullName).MinimumLength(2).WithMessage("User Full Name cannot be less than 2 characters!");
            RuleFor(x => x.FullName).MaximumLength(50).WithMessage("User Full Name cannot be more than 50 characters!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-mail cannot be empty!").EmailAddress().WithMessage("A valid e-mail address is required!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty!");
        }
    }
}
