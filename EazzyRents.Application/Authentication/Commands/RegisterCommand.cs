using EazzyRents.Application.Authentication.Common;
using EazzyRents.Core.Enums;
using ErrorOr;
using MediatR;

namespace EazzyRents.Application.Authentication.Commands
{
    public sealed record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        UserRole UserRole
        ) : IRequest<ErrorOr<AuthResult>>;

}
