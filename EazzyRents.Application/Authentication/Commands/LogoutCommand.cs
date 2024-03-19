using MediatR;

namespace EazzyRents.Application.Authentication.Commands
{
    public record LogoutCommand : IRequest<Unit>
    {
    }
}
