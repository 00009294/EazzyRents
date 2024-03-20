using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Landlord.Queries
{
    public record GetAllByRequestStatusQuery(RequestStatus requestStatus, int landlordId) : IRequest<List<Request>>;
}
