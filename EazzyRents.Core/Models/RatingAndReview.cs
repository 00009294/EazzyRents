using System.ComponentModel.DataAnnotations;

namespace EazzyRents.Core.Models
{/// <summary>
/// Before making a deal both sides can see all history reviews each other, to make sure whith whome they are dealing
/// </summary>
    public class RatingAndReview
    {
        public int Id { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int ReceiverId { get; set; }
        [Required]
        public string ReviewMessage { get; set; }
        [Required]

        public int Rating
        {
            get => Rating;
            set
            {
                if (value >= 1 && value <= 5)
                {
                    Rating = value;
                }
                else
                {
                    throw new ArgumentException("Rating must be between 1 and 5.");
                }
            }
        }
    }
}
