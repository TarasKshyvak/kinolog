using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class MovieNameModelValidator : AbstractValidator<MovieNameModel>
    {
        public MovieNameModelValidator()
        {
            RuleFor(movie => movie.Name)
                .NotEmpty()
                .WithMessage("Name is required field");
        }
    }
}
