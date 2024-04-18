using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Enums;
using MediatR;

namespace EazzyRents.Application.UseCases.RatingsAndReviews.Users.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, bool>
    {
        private readonly IRatingAndReviewRepository ratingAndReview;
        private readonly IUserRepository userRepository;

        public CreateCommandHandler(IRatingAndReviewRepository ratingAndReview,
            IUserRepository userRepository)
        {
            this.ratingAndReview = ratingAndReview;
            this.userRepository = userRepository;
        }
        public Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var sender = userRepository.GetUserById(request.ratingAndReview.SenderId.ToString());
            var receiver = userRepository.GetUserById(request.ratingAndReview.ReceiverId.ToString());
            if (sender != null && receiver != null)
            {
                if (sender.UserRole == UserRole.Tenant && receiver.UserRole == UserRole.Tenant)
                {
                    return Task.FromResult(false);
                }

                if (sender.UserRole == UserRole.Landlord && receiver.UserRole == UserRole.Landlord)
                {
                    return Task.FromResult(false);
                }
            }

            return Task.FromResult(ratingAndReview.Create(request.ratingAndReview));

        }
    }
}
