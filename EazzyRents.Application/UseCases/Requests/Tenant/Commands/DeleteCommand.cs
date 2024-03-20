using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Tenant.Commands
{
    public record DeleteCommand(int id) : IRequest<bool>;
}
