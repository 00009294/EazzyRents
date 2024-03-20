using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Tenant.Commands
{
    public record CreateCommand(Request request) : IRequest<bool>;
}
