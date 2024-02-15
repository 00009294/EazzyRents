using EazzyRents.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EazzyRents.Application.RealEstates.Commands
{
      public record UpdateCommand(
        int Id,
        string Descriprion,
        string Address,
        double Price,
        List<IFormFile> Images,
        string PhoneNumber,
        int OwnerId,
        RealEstateStatus Status
        ) : IRequest<bool>;

}
