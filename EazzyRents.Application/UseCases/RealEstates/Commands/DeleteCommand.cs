using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Commands
{
    public record DeleteCommand(int id) : IRequest<bool>;
}
