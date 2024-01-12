using EazzyRents.Core.Enums;
using MediatR;

namespace EazzyRents.Application.RealEstates.Commands
{
    public record UpdateCommand(
        int Id,
        string Descriprion,
        string Address,
        double Price,
        byte[] Photo,
        string PhoneNumber,
        RealEstateStatus Status
        ) : IRequest<bool>;

}
