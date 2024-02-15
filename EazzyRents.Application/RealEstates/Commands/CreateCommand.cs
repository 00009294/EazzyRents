using EazzyRents.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EazzyRents.Application.RealEstates.Commands
{
      public class CreateCommand : IRequest<bool>
      {

            public string Description { get; init; }
            public string Address { get; init; }
            public double Price { get; init; }
            public string PhoneNumber { get; init; }
            public string Email { get; init; }
            [NotMapped]
            public List<IFormFile> Images { get; set; }
            public RealEstateStatus RealEstateStatus { get; init; }
      }

}
