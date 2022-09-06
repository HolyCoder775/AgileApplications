﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserRoleValidator : AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID cannot be empty!");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role ID cannot be empty!");
        }
    }
}
