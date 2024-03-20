using AutoMapper;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using MediatR;

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
                Email = user.Email
            };

            if (request.ImageDataList != null)
            {
                foreach (var image in request.ImageDataList)
                {
                    imageRepository.UploadImage(image, request.Email);

                }
            }

            var createdRealEstate = realEstateRepository.Create(realEstate);

            return Task.FromResult(createdRealEstate != null);
        }
    }
}
