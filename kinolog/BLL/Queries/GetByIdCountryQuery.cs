using BLL.Models;
using MediatR;

namespace BLL.Queries
{
    public record GetByIdCountryQuery(Guid Id) : IRequest<CountryModel>;
}
