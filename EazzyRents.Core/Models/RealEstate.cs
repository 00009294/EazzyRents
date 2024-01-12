using EazzyRents.Core.Enums;

namespace EazzyRents.Core.Models
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public byte[] Photo { get; set; }
        public string PhoneNumber { get; set; }
        public User OwnerId { get; set; }
        public RealEstateStatus RealEstateStatus { get; set; }
    }
}
