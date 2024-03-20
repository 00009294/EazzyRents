using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public record GetByPriceQuery(double price) : IRequest<List<RealEstate>>;

}
