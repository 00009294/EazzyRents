using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public record GetAllQuery() : IRequest<List<RealEstate>>;

}
