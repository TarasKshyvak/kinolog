using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class CreatorNameModelValidator : AbstractValidator<CreatorNameModel>
    {
        public CreatorNameModelValidator()
        {
            RuleFor(creator => creator.Fullname)
                .MinimumLength(3)
                .WithMessage("Minimum length of fullname field is 5 characters");
        }
    }
}
