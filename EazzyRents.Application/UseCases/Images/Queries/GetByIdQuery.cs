using MediatR;

namespace EazzyRents.Application.UseCases.Images.Queries
{
    public record GetByIdQuery(int realEstateId) : IRequest<List<string>>;
}
