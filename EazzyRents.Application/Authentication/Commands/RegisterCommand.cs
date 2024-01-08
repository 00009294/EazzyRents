using EazzyRents.Application.Authentication.Common;
using EazzyRents.Core.Enums;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
