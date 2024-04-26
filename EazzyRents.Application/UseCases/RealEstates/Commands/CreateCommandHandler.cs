using AutoMapper;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace EazzyRents.Application.UseCases.RealEstates.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, bool>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IImageRepository imageRepository;

        public CreateCommandHandler(IRealEstateRepository realEstateRepository,
            IUserRepository userRepository,
            IImageRepository imageRepository,
            IMapper mapper)
        {
            this.realEstateRepository = realEstateRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.imageRepository = imageRepository;
        }

        public Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
        {

            if (request == null)
                return Task.FromResult(false);

            var user = userRepository.GetUserByEmail(request.Email);

            if (user == null || user.UserRole != UserRole.Landlord || user.Email == null)
            {
                throw new UnauthorizedAccessException();
            }

            var realEstate = new RealEstate
            {
                Description = request.Description,
                Address = request.Address,
                Price = request.Price,
                PhoneNumber = request.PhoneNumber,
                RealEstateStatus = request.RealEstateStatus,
                About  = request.About,
                Email = user.Email,
                Longitude = request.Longitude,
                Latitude = request.Latitude,
                ImageUrls = new List<string>()
            };


            List<string> allUrls = new List<string>();
            if (request.ImageDataList != null)
            {
                foreach (var image in request.ImageDataList)
                {
                    var imageList = imageRepository.UploadImage(image, request.Email);
                    allUrls.Add(imageList.Url + "/" + imageList.FileName);
                }

                realEstate.ImageUrls = allUrls;

            }
            else
            {
                AddDefaultImages(realEstate);
            }

            var createdRealEstate = realEstateRepository.Create(realEstate);

            return Task.FromResult(createdRealEstate != null);
        }

        private void AddDefaultImages(RealEstate realEstate)
        {
            // Add your default image URLs here
            List<string> defaultUrls = new List<string>
            {
                "white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9",
                "ff86126d4865dcca465bdb8d611468a5l-m4075378552od-w480_h360",
                "My project - 2023-06-20T095818.329 (1)_0",
                "Truoba-320-modern-house-plans-1200x800"
            };

            realEstate.ImageUrls = defaultUrls;
        }

    }
}
