﻿using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Queries
{
    public class GetByPriceQueryHandler : IRequestHandler<GetByPriceQuery, List<RealEstate>>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IImageRepository imageRepository;

        public GetByPriceQueryHandler(IRealEstateRepository realEstateRepository, IImageRepository imageRepository)
        {
            this.realEstateRepository = realEstateRepository;
            this.imageRepository = imageRepository;
        }

        public Task<List<RealEstate>> Handle(GetByPriceQuery request, CancellationToken cancellationToken)
        {
            List<RealEstate> realEstateList = this.realEstateRepository.GetByPrice(request.price);
            
            foreach (var realEstate in realEstateList)
            {
                var imageList = this.imageRepository.GetImages(realEstate.Email);
                realEstate.ImageDataList = imageList;
            }

            return Task.FromResult(realEstateList);
        }
    }
}
