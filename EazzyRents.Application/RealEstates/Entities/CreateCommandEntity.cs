using EazzyRents.Core.Enums;
using EazzyRents.Core.Models.BlobStorage;

namespace EazzyRents.Application.RealEstates.Entities
{
    public class CreateCommandEntity
    {
        public int Id { get; init; }
        public string Description { get; init; }
        public string Address { get; init; }
        public double Price { get; init; }
        public string PhoneNumber { get; init; }
        public int OwnerId { get; init; }
        public List<BlobContent> Images { get; init; }
        public RealEstateStatus RealEstateStatus { get; init; }
    }
}
