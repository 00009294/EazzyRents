using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Queries
{
    public record GetByPriceQuery(double price) : IRequest<List<RealEstate>>;

}
