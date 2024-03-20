using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Enums;
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
            var realEstate = realEstateRepository.GetById(request.realEstateRatingAndReview.RealEstateId);
            var tenant = userRepository.GetUserById(request.realEstateRatingAndReview.SenderId);

            if (realEstate == null || tenant == null || tenant.UserRole != UserRole.Tenant)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(realEstateRatingAndReviewRepository.Create(request.realEstateRatingAndReview));

        }
    }
}
