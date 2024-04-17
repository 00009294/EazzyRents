namespace EazzyRents.Core.Models
{
    public class RealEstateRatingAndReview
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string ReviewMessage { get; set; } = string.Empty;
        public int RealEstateId { get; set; }

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
