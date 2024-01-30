using EazzyRents.Core.Enums;
using EazzyRents.Core.Models.BlobStorage;

namespace EazzyRents.Core.Models
{
      public class RealEstate
      {
            public int Id { get; set; }
            public string Description { get; set; }
            public string Address { get; set; }
            public double Price { get; set; }
            public string PhoneNumber { get; set; }
            public List<BlobContent> Images { get; set; }
            public RealEstateStatus RealEstateStatus { get; set; }

            public int OwnerId { get; set; }
            public User Owner { get; set; }
      }
}
