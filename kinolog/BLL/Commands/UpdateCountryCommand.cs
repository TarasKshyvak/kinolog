using BLL.Models;
using MediatR;

namespace BLL.Commands
{
    public record UpdateCountryCommand(CountryModel Country) : IRequest<CountryModel>;
}
