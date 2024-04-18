using EazzyRents.Application.UseCases.RealEstates.Entities;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public record GetByIdQuery(int id) : IRequest<GetByIdQueryEntity>;
}
