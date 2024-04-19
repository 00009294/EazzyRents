using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using EazzyRents.Infrastructure.Data;

namespace EazzyRents.Infrastructure.Persistence
{
    public class RealEstateRatingAndReviewRepository : IRealEstateRatingAndReviewRepository
    {
        private readonly AppDbContext appDbContext;

        public RealEstateRatingAndReviewRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public bool Create(RealEstateRatingAndReview realEstateRatingAndReview)
        {
            this.appDbContext.RealEstateRatingAndReviews.Add(realEstateRatingAndReview);
            return this.appDbContext.SaveChanges() > 0;
        }

        public bool Delete(int realEstateId)
        {

            var selectedRealEstate = this.appDbContext.RealEstateRatingAndReviews.Where(r => r.RealEstateId == realEstateId);
            
            if(selectedRealEstate != null)
            {
                foreach(var estate in selectedRealEstate)
                {
                    this.appDbContext.RealEstateRatingAndReviews.Remove(estate);
                    this.appDbContext.SaveChanges();
                }

                return true;
            }

            return false;
        }

        public List<RealEstateRatingAndReview> GetAll()
        {
            return this.appDbContext.RealEstateRatingAndReviews.ToList();
        }
    }
}
