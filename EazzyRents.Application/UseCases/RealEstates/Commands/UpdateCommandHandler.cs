using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Commands
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IImageRepository imageRepository;

        public UpdateCommandHandler(IRealEstateRepository realEstateRepository,
            IImageRepository imageRepository)
        {
            this.realEstateRepository = realEstateRepository;
            this.imageRepository = imageRepository;
        }
        public Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {

            var realEstate = new RealEstate()
            {
                Id = request.Id,
                Description = request.Descriprion,
                Address = request.Address,
                Price = request.Price,
                OwnerId = request.OwnerId,
                PhoneNumber = request.PhoneNumber,
                RealEstateStatus = request.Status
            };
            return Task.FromResult(realEstateRepository.Update(realEstate));
        }
    }
}
