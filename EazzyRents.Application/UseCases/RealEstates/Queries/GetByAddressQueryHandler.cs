using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public class GetByAddressQueryHandler : IRequestHandler<GetByAddressQuery, List<RealEstate>>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IImageRepository imageRepository;

        public GetByAddressQueryHandler(IRealEstateRepository realEstateRepository,
            IImageRepository imageRepository)
        {
            this.realEstateRepository = realEstateRepository;
            this.imageRepository = imageRepository;
        }
        public Task<List<RealEstate>> Handle(GetByAddressQuery request, CancellationToken cancellationToken)
        {
            List<RealEstate> realEstateList = realEstateRepository.GetByAddress(request.address);

            //foreach (var realEstate in realEstateList)
            //{
            //    var imageList = imageRepository.GetImages(realEstate.Email);
            //    realEstate.ImageUrls = imageList;
            //}

            return Task.FromResult(realEstateList);
        }
    }
}
