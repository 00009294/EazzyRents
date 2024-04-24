using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RatingsAndReviews.RealEstates.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, bool>
    {
        private readonly IRealEstateRatingAndReviewRepository realEstateRatingAndReviewRepository;
        private readonly IUserRepository userRepository;
        private readonly IRealEstateRepository realEstateRepository;

        public CreateCommandHandler(
            IRealEstateRatingAndReviewRepository realEstateRatingAndReviewRepository,
            IUserRepository userRepository,
            IRealEstateRepository realEstateRepository)
        {
            this.realEstateRatingAndReviewRepository = realEstateRatingAndReviewRepository;
            this.userRepository = userRepository;
            this.realEstateRepository = realEstateRepository;
        }
        public Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var realEstate = this.realEstateRepository.GetById(request.RealEstateId);
                var tenant = this.userRepository.GetUserById(request.SenderId);

                if (realEstate == null || tenant == null)
                {
                    return Task.FromResult(false);
                }

                if (!(request.Rating > 0 && request.Rating < 6))
                {
                    return Task.FromResult(false);
                }

                var realEstateRatingAndReview = new RealEstateRatingAndReview
                {
                    SenderId = tenant.Id,
                    RealEstateId = realEstate.Id,
                    ReviewMessage = request.ReviewMessage,
                    Rating = request.Rating,
                    CreatedDate = DateTime.UtcNow
                };
                    
                var result = realEstateRatingAndReviewRepository.Create(realEstateRatingAndReview);

                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
