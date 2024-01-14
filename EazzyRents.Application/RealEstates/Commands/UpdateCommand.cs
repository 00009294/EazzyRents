using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Commands
{
    public record UpdateCommand(
        int Id,
        string Descriprion,
        string Address,
        double Price,
        List<Image> Images,
        string PhoneNumber,
        RealEstateStatus Status
        ) : IRequest<bool>;

}
