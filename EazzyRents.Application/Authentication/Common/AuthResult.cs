using EazzyRents.Core.Models;

namespace EazzyRents.Application.Authentication.Common
{
    public record AuthResult
    (
        User User,
        string Token
        );
}
