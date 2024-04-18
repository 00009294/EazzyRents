using System.ComponentModel.DataAnnotations;

namespace EazzyRents.Core.Models
{
    public class RealEstateRatingAndReview
    {
        public int Id { get; set; }
        public string SenderId { get; set; } = string.Empty;
        public string ReviewMessage { get; set; } = string.Empty;
        public int RealEstateId { get; set; }
        public DateTime CreatedDate { get; set; } 
        public int Rating {  get; set; }
    }
}
