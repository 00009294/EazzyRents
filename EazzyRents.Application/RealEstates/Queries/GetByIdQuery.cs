using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Queries
{
    public record GetByIdQuery(int id) : IRequest<RealEstate>;
}
