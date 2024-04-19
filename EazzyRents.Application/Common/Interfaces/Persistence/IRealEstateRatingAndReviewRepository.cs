using EazzyRents.Core.Models;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IRealEstateRatingAndReviewRepository
    {
        bool Create(RealEstateRatingAndReview realEstateRatingAndReview);
        bool Delete(int realEstateId);
        List<RealEstateRatingAndReview> GetAll();
    }
}
