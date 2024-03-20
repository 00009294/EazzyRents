using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Tenant.Queries
{
    public record GetAllQuery : IRequest<List<Request>>;

}
