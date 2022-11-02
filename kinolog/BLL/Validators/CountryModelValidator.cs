using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class CountryModelValidator : AbstractValidator<CountryModel>
    {
        public CountryModelValidator()
        {
            RuleFor(country => country.Name)
                .NotEmpty()
                .WithMessage("Country name is required field")
                .MinimumLength(3)
                .WithMessage("Minimum length of country name is 3 characters");
        }
    }
}
