using EazzyRents.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace EazzyRents.Core.Models
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<ImageData> ImageDataList { get; set; } 
        public RealEstateStatus RealEstateStatus { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }
    }
}
