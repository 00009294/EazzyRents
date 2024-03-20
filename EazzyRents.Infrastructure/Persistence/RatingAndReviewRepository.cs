using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using EazzyRents.Infrastructure.Data;

namespace EazzyRents.Infrastructure.Persistence
{
    public class RatingAndReviewRepository : IRatingAndReviewRepository
    {
        private readonly AppDbContext appDbContext;

        public RatingAndReviewRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public bool Create(RatingAndReview ratingAndReview)
        {
            this.appDbContext.RatingAndReviews.Add(ratingAndReview);

            return this.appDbContext.SaveChanges() > 0;
        }
    }
}
