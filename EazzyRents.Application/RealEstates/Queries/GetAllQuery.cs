using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Queries
{
    public record GetAllQuery() : IRequest<List<RealEstate>>;

}
