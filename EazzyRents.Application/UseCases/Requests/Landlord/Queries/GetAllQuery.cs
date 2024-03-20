using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Landlord.Queries
{
    public class GetAllQuery : IRequest<List<Request>>
    {
        public int LandlordId { get; set; }
    }
}
