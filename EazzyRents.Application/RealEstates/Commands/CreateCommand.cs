using EazzyRents.Application.RealEstates.Entities;
using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Commands
{
    public class CreateCommand : IRequest<bool>
    {
        
        public string Description { get; init; }
        public string Address { get; init; }
        public double Price { get; init; }
        public string PhoneNumber { get; init; }
        public int OwnerId { get; init; }
        public List<Image> Images { get; init; }
        public RealEstateStatus RealEstateStatus { get; init; }
    }

}
