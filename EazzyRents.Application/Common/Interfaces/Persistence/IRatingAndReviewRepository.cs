using EazzyRents.Core.Models;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IRatingAndReviewRepository
    {
        bool Create(RatingAndReview ratingAndReview);
    }
}
