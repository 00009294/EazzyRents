using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public record GetByPriceQuery(double fromPrice, double toPrice) : IRequest<List<RealEstate>>;

}
