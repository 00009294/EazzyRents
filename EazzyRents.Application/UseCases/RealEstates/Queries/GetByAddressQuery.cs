using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public record GetByAddressQuery(Address address) : IRequest<List<RealEstate>>;

}
