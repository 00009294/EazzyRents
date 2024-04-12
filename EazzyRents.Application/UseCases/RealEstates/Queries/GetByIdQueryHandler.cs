using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, RealEstate?>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IImageRepository imageRepository;

        public GetByIdQueryHandler(IRealEstateRepository realEstateRepository,
            IImageRepository imageRepository)
        {
            this.realEstateRepository = realEstateRepository;
            this.imageRepository = imageRepository;
        }
        public Task<RealEstate?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            RealEstate? realEstate = realEstateRepository.GetById(request.id);

            if (realEstate != null)
            {
                var imageList = imageRepository.GetImages(realEstate.Email);
                realEstate.ImageUrls = imageList;
            }

            return Task.FromResult(realEstate);
        }
    }
}
