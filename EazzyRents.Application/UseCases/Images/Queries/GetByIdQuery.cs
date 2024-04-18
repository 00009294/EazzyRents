using MediatR;

namespace EazzyRents.Application.UseCases.Images.Queries
{
    public record GetByIdQuery(int id) : IRequest<List<string>>;
}
