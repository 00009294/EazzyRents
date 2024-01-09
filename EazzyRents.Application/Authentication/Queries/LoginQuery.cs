using EazzyRents.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace EazzyRents.Application.Authentication.Queries
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<AuthResultForLogin>;

}
