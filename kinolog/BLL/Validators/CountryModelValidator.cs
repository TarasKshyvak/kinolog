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
                .MinimumLength(2)
                .WithMessage("Minimum length of country name is 2 characters");
        }
    }
}
