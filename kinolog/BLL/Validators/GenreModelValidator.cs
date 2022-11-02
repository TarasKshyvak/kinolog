using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class GenreModelValidator : AbstractValidator<GenreModel>
    {
        public GenreModelValidator()
        {
            RuleFor(genre => genre.Name)
                .NotEmpty()
                .WithMessage("Genre name is required field");
        }
    }
}
