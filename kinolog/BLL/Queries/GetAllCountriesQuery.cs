using BLL.Models;
using MediatR;

namespace BLL.Queries
{
    public record GetAllCountriesQuery() : IRequest<IEnumerable<CountryModel>>;
}
