using EazzyRents.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EazzyRents.Application.UseCases.RealEstates.Commands
{
    public class CreateCommandEstate : IRequest<bool>
    {

        public string Description { get; set; }
        public double Price { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string About { get; set; }
        public List<IFormFile>? ImageDataList { get; set; }
        public Address Address { get; set; }
        public RealEstateStatus RealEstateStatus { get; set; }
    }

}
