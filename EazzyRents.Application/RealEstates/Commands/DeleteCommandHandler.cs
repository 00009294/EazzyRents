using EazzyRents.Application.Common.Interfaces.Persistence;
using MediatR;

namespace EazzyRents.Application.RealEstates.Commands
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IRealEstateRepository realEstateRepository;

        public DeleteCommandHandler(IRealEstateRepository realEstateRepository)
        {
            this.realEstateRepository = realEstateRepository;
        }
        public Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.realEstateRepository.Delete(request.id));
        }
    }
}
