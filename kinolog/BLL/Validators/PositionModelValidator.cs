using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class PositionModelValidator : AbstractValidator<PositionModel>
    {
        public PositionModelValidator()
        {
            RuleFor(position => position.Name)
                .NotEmpty()
                .WithMessage("Position name is required")
                .MinimumLength(4)
                .WithMessage("Minimum length of position name is 5 characters");
        }
    }
}
