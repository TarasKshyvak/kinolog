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
                .WithMessage("Ussername is required field")
                .Must(name => name.Count() < 30)
                .WithMessage("Ussername should be less than 30 sumbols")
                .Must(name => name.Count() > 1)
                .WithMessage("Ussername should be over 1 symbols");

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

            RuleFor(user => user.MoviesRatings)
                .NotEmpty();
        }
    }
}
