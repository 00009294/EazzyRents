using EazzyRents.Application.Common.Interfaces.Persistence;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Commands
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IImageRepository imageRepository;
        private readonly IRealEstateRatingAndReviewRepository realEstateRatingAndReviewRepository;

        public DeleteCommandHandler(
              IRealEstateRepository realEstateRepository,
              IImageRepository imageRepository,
              IRealEstateRatingAndReviewRepository realEstateRatingAndReviewRepository
               
              )
        {
            this.realEstateRepository = realEstateRepository;
            this.imageRepository = imageRepository;
            this.realEstateRatingAndReviewRepository = realEstateRatingAndReviewRepository;
        }
        public Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var realEstate = realEstateRepository.GetById(request.id);
            if (realEstate != null)
            {
                //this.imageRepository.DeleteImages(realEstate.Email);
            }
            this.realEstateRatingAndReviewRepository.Delete(realEstate.Id);

            return Task.FromResult(realEstateRepository.Delete(request.id));
        }
    }
}
