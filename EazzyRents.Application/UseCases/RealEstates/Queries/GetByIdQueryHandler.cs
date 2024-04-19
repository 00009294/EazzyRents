using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Application.UseCases.RealEstates.Entities;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdQueryEntity>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IUserRepository userRepository;

        public GetByIdQueryHandler(IRealEstateRepository realEstateRepository,
            IUserRepository userRepository)
        {
            this.realEstateRepository = realEstateRepository;
            this.userRepository = userRepository;
        }
        public Task<GetByIdQueryEntity> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var realEstate = realEstateRepository.GetById(request.id);
            if (realEstate == null)
            {
                throw new ArgumentNullException("Not Found Entity");
            }

            var owner = this.userRepository.GetUserByEmail(realEstate.Email);
            if (owner == null || owner.UserName == null)
            {
                throw new ArgumentNullException("Not Found Entity");
            }

            GetByIdQueryEntity entity = new GetByIdQueryEntity
            {
                Id = request.id,
                Description = realEstate.Description,
                Email = realEstate.Email,
                Owner = owner.UserName,
                Price = realEstate.Price,
                About = realEstate.About,
                PhoneNumber = realEstate.PhoneNumber,
                Latitude = realEstate.Latitude,
                Longitude = realEstate.Longitude,
                ImageUrls = realEstate.ImageUrls,
                Address = realEstate.Address,
                RealEstateStatus = realEstate.RealEstateStatus
            };

            return Task.FromResult(entity);
        }
    }
}
