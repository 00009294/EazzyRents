using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Application.UseCases.RatingsAndReviews.RealEstates.Entities;
using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.RatingsAndReviews.RealEstates.Queries
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, List<RatingAndReviewEntity>>
    {
        private readonly IRealEstateRatingAndReviewRepository realEstateRatingAndReviewRepository;
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IUserRepository userRepository;

        public GetByIdQueryHandler(
            IRealEstateRatingAndReviewRepository realEstateRatingAndReviewRepository,
            IRealEstateRepository realEstateRepository,
            IUserRepository userRepository
            )
        {
            this.realEstateRatingAndReviewRepository = realEstateRatingAndReviewRepository;
            this.realEstateRepository = realEstateRepository;
            this.userRepository = userRepository;
        }
        public Task<List<RatingAndReviewEntity>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            List<RatingAndReviewEntity> ratingAndReviewEntities = new List<RatingAndReviewEntity>();
            var realEstate = this.realEstateRepository.GetById(request.realEstateId);
            var allReviews = this.realEstateRatingAndReviewRepository.GetAll().Where(c=>c.RealEstateId == request.realEstateId);
            //var allSenders = this.userRepository.GetUserByEmail(realEstate.Email);
            
            foreach (var review in allReviews)
            {
                RatingAndReviewEntity ratingAndReviewEntity = new RatingAndReviewEntity();
                
                ratingAndReviewEntity.SenderName = this.userRepository.GetUserById(review.SenderId).UserName;
                ratingAndReviewEntity.ReviewMessage = review.ReviewMessage;
                ratingAndReviewEntity.Rating = review.Rating;
                ratingAndReviewEntity.RealEstateId = review.RealEstateId;
                ratingAndReviewEntity.CreatedDate = review.CreatedDate;

                ratingAndReviewEntities.Add(ratingAndReviewEntity);
            }

            var result = ratingAndReviewEntities.OrderByDescending(r=>r.CreatedDate).ToList();

            return Task.FromResult(result);

        }
    }
}
