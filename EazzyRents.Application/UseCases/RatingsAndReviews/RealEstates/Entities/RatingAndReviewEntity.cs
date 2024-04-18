using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.RatingsAndReviews.RealEstates.Entities
{
    public class RatingAndReviewEntity
    {
        public string SenderName{ get; set; } = String.Empty;
        public string ReviewMessage { get; set; } = String.Empty;
        public int RealEstateId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Rating { get; set; }

    }
}
