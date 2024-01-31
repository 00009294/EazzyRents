using EazzyRents.Core.Enums;
using EazzyRents.Core.Models.BlobStorage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EazzyRents.Application.RealEstates.Commands
{
      public class CreateCommand : IRequest<bool>
      {

            public string Description { get; init; }
            public string Address { get; init; }
            public double Price { get; init; }
            public string PhoneNumber { get; init; }
            [NotMapped]
            public List<IFormFile> Images { get; init; }
            public RealEstateStatus RealEstateStatus { get; init; }
            public int OwnerId { get; init; }
      }

}
