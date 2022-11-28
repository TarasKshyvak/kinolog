using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty()
                .WithMessage("Username is required field")
                .Must(name => name.Count() <= 30)
                .WithMessage("Username should be less or equal to 30 symbols")
                .Must(name => name.Count() > 1)
                .WithMessage("Username should be over 1 symbols");

            RuleFor(user => user.BirthDate)
                .NotEmpty()
                .WithMessage("BirthDate is required field")
                .LessThanOrEqualTo(DateTime.Today)
                .GreaterThanOrEqualTo(new DateTime(1910, 1, 1))
                .WithMessage("Accessible BirthDate from year 1910 to today");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email field is required");

            RuleFor(user => user.Gender)
                .NotEmpty()
                .WithMessage("Gender field is required");
        }
    }
}
