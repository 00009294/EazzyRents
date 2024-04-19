using EazzyRents.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EazzyRents.Application.UseCases.RealEstates.Commands
{
    public class CreateCommand : IRequest<bool>
    {

        public string Description { get; init; }
        public double Price { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
        public string Longitude { get; init; }
        public string Latitude { get; init; }
        public string About { get; init; }  
        public List<IFormFile> ImageDataList { get; set; }
        public Address Address { get; init; }
        public RealEstateStatus RealEstateStatus { get; init; }
    }

}
