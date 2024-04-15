using EazzyRents.Core.Enums;

namespace EazzyRents.Core.Models
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public double Price { get; set; }
        public string PhoneNumber { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Latitude { get; set; } = String.Empty;
        public string Longitude { get; set; } = String.Empty;
        public List<string> ImageUrls { get; set; } = new List<string>();
        public Address Address { get; set; } 
        public RealEstateStatus RealEstateStatus { get; set; }

    }
}
