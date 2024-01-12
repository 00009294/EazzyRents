using MediatR;

namespace EazzyRents.Application.RealEstates.Commands
{
    public record DeleteCommand(int id) : IRequest<bool>;
}
