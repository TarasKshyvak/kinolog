using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class CreatorModelValidator : AbstractValidator<CreatorModel>
    {
        public CreatorModelValidator()
        {
            RuleFor(creator => creator.FirstName)
                .NotEmpty()
                .WithMessage("First name is required")
                .MinimumLength(2)
                .WithMessage("Minimum length of first name is 2 characters");

            RuleFor(creator => creator.LastName)
                .NotEmpty()
                .WithMessage("Last name is required")
                .MinimumLength(2)
                .WithMessage("Minimum length of last name is 2 characters");

            RuleFor(creator => creator.Country)
                .NotEmpty()
                .WithMessage("Country field is required")
                .MinimumLength(2)
                .WithMessage("Minimum length of country field is 2 characters");
        }
    }
}
