using EazzyRents.Core.Enums;
using EazzyRents.Core.Models.BlobStorage;
using MediatR;

namespace EazzyRents.Application.RealEstates.Commands
{
      public record UpdateCommand (
        int Id,
        string Descriprion,
        string Address,
        double Price,
        List<BlobContent> Images,
        string PhoneNumber,
        int OwnerId,
        RealEstateStatus Status
        ) : IRequest<bool>;

}
