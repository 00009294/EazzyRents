using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Queries
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<RealEstate>>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IImageRepository imageRepository;

        public GetAllQueryHandler(IRealEstateRepository realEstateRepository,
            IImageRepository imageRepository)
        {
            this.realEstateRepository = realEstateRepository;
            this.imageRepository = imageRepository;
        }
        public Task<List<RealEstate>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            List<RealEstate> realEstateList = this.realEstateRepository.GetAll();
            
            foreach(var realEstate in realEstateList)
            {
                var images = this.imageRepository.GetImages(realEstate.Email);
                realEstate.ImageDataList = images;
            }
            
            return Task.FromResult(realEstateList);
        }
    }
}
