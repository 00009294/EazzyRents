using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Tenants.Queries
{
    public record GetByIdQuery(int tenantId) : IRequest<User>;
}
