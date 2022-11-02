using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class RatingModelValidator : AbstractValidator<RatingModel>
    {
        public RatingModelValidator()
        {
            RuleFor(rating => rating.Mark)
                .GreaterThan(0)
                .LessThan(11);

            RuleFor(rating => rating.Movie)
                .NotEmpty()
                .WithMessage("Movie name is required field");
        }
    }
}
