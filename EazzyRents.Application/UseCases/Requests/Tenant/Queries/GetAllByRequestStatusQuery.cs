using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Tenant.Queries
{
    public record GetAllByRequestStatusQuery(int tenantId, RequestStatus requestStatus) : IRequest<List<Request>>;
}
