using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class MovieCreatorModelValidator : AbstractValidator<MovieCreatorModel>
    {
        public MovieCreatorModelValidator()
        {
            RuleFor(mc => mc.Creator)
                .NotEmpty()
                .WithMessage("Creator field is required");

            RuleFor(mc => mc.Movie)
                .NotEmpty()
                .WithMessage("Movie field is required");

            RuleFor(mc => mc.Position)
                .NotEmpty()
                .WithMessage("Position field is required");

        }
    }
}
