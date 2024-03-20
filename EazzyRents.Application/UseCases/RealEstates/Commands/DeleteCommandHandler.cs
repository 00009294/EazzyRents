using EazzyRents.Application.Common.Interfaces.Persistence;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Commands
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IImageRepository imageRepository;

        public DeleteCommandHandler(
              IRealEstateRepository realEstateRepository,
              IImageRepository imageRepository
              )
        {
            this.realEstateRepository = realEstateRepository;
            this.imageRepository = imageRepository;
        }
        public Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var realEstate = realEstateRepository.GetById(request.id);
            if (realEstate != null)
            {
                imageRepository.DeleteImages(realEstate.Email);
            }

            return Task.FromResult(realEstateRepository.Delete(request.id));
        }
    }
}
