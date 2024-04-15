using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<RealEstate>>
    {
        private readonly IRealEstateRepository realEstateRepository;

        public GetAllQueryHandler(IRealEstateRepository realEstateRepository
            )
        {
            this.realEstateRepository = realEstateRepository;
        }
        public Task<List<RealEstate>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            List<RealEstate> realEstateList = realEstateRepository.GetAll();

            //foreach (var realEstate in realEstateList)
            //{
            //    var images = imageRepository.GetImages(realEstate.Email);

            //    realEstate.ImageUrls = images;
            //}

            return Task.FromResult(realEstateList);
        }
    }
}
