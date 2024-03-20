using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public record GetByAddressQuery(string address) : IRequest<List<RealEstate>>;

}
