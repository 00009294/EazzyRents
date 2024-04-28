using EazzyRents.Application.Common.Interfaces.Persistence;
using MediatR;

namespace EazzyRents.Application.UseCases.Images.Queries
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, List<string>>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IImageRepository imageRepository;

        public GetByIdQueryHandler(IRealEstateRepository realEstateRepository, 
                IImageRepository imageRepository)
        {
            this.realEstateRepository = realEstateRepository;
            this.imageRepository = imageRepository;
        }
        public Task<List<string>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            //var allImages = this.realEstateRepository.GetAll().Where(r => r.Id == request.realEstateId);

            //foreach (var image in allImages)
            //{
            //    return Task.FromResult(image.ImageUrls);
            //}

            //return Task.FromResult(new List<string>());

            var realEstate = this.realEstateRepository.GetById(request.realEstateId);

            if(realEstate == null)
            {
                return Task.FromResult(new List<string>());
            }

            var allUrls = this.imageRepository.GetImages(realEstate.Email);

            return Task.FromResult(allUrls);

        }
    }
}
