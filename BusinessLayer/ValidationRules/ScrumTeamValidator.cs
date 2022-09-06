using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ScrumTeamValidator : AbstractValidator<ScrumTeam>
    {
        public ScrumTeamValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Permission name cannot be empty!");
        }
    }
}
