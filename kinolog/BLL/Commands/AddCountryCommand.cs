using BLL.Models;
using MediatR;

namespace BLL.Commands
{
    public record AddCountryCommand(CountryModel Country) : IRequest<CountryModel>;
}
