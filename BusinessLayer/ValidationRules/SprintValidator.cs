using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SprintValidator : AbstractValidator<Sprint>
    {
        [Obsolete]
        public SprintValidator()
        {
            RuleFor(x => x.ScrumTeamId).NotEmpty().WithMessage("Permission name cannot be empty!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Permission name cannot be empty!");
            RuleFor(x => x.StartDate).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                    .Must(date => date != default(DateTime))
                    .WithMessage("Start date is required");
            RuleFor(x => x.EndDate).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                    .Must(date => date != default(DateTime))
                    .WithMessage("End date is required");

        }
    }
}
