using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class MovieModelValidator : AbstractValidator<MovieModel>
    {
        public MovieModelValidator()
        {
            RuleFor(movie => movie.Name)
                .NotEmpty()
                .WithMessage("Movie name is required field");

            RuleFor(movie => movie.Year)
                .GreaterThanOrEqualTo(1895)
                .WithMessage("Minimum year value is 1895");

            RuleForEach(movie => movie.MovieCreatorModels)
                .NotNull()
                .WithMessage("Values in MovieCreators collection cannot be null");
        }
    }
}
