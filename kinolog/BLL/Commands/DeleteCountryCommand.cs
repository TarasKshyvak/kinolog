using BLL.Models;
using MediatR;

namespace BLL.Commands
{
    public record DeleteCountryCommand(Guid Id) : IRequest;
}
