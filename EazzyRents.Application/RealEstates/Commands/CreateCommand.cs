using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Commands
{
    public record CreateCommand(
        int Id,
        string Descriprion,
        string Address,
        double Price,
        byte[] Photo,
        string PhoneNumber,
        User OwnerId,
        RealEstateStatus Status
        ) : IRequest<bool>;

}
