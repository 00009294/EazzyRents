using MediatR;

namespace EazzyRents.Application.UseCases.Images.Queries
{
    public record GetAllQuery() : IRequest<List<string>>;
}
