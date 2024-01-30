using EazzyRents.Application.Authentication.Common;
using EazzyRents.Core.Enums;
using MediatR;

namespace EazzyRents.Application.Authentication.Commands
{
      public sealed record RegisterCommand (
        string UserName,
        string Email,
        string Password,
        UserRole UserRole
        ) : IRequest<AuthResultForRegistration>;

}
