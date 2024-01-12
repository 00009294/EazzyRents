using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Queries
{
    public record GetByAddressQuery(string address) : IRequest<List<RealEstate>>;

}
