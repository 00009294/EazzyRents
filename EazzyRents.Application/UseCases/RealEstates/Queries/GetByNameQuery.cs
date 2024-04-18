using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public record GetByNameQuery(string name) : IRequest<List<RealEstate>>;
}
