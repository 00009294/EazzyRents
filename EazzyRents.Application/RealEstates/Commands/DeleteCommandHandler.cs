using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Application.Common.Interfaces.Services;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Commands
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IImageRepository imageRepository;
        private readonly IBlobService blobService;

        public DeleteCommandHandler(
              IRealEstateRepository realEstateRepository,
              IImageRepository imageRepository,
              IBlobService blobService)
        {
            this.realEstateRepository = realEstateRepository;
            this.imageRepository = imageRepository;
            this.blobService = blobService;
        }
        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var realEstate = this.realEstateRepository.GetById(request.id);
            if (realEstate != null)
            {
                this.imageRepository.DeleteImages(realEstate.Email);
            }

            return this.realEstateRepository.Delete(request.id);
        }
    }
}
