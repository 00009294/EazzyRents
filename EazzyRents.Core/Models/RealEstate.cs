using EazzyRents.Core.Enums;

namespace EazzyRents.Core.Models
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public double Price { get; set; }
        public string PhoneNumber { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public List<ImageData> ImageDataList { get; set; }
        public RealEstateStatus RealEstateStatus { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }
    }
}
