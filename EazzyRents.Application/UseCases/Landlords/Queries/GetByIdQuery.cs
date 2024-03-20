using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Landlords.Queries
{
    public record GetByIdQuery(int landlordId) : IRequest<User>;

}
