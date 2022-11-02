using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class GenreNameModelValidator : AbstractValidator<GenreNameModel>
    {
        public GenreNameModelValidator()
        {
            RuleFor(genre => genre.Name)
                .NotEmpty()
                .WithMessage("Genre name is required field");
        }
    }
}
