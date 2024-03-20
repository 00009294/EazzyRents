using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Enums;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Tenant.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, bool>
    {
        private readonly IRequestRepository requestRepository;
        private readonly IRealEstateRepository realEstateRepository;

        public CreateCommandHandler(
            IRequestRepository requestRepository,
            IRealEstateRepository realEstateRepository)
        {
            this.requestRepository = requestRepository;
            this.realEstateRepository = realEstateRepository;
        }
        public Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var realEstate = realEstateRepository.GetById(request.request.RealEstateId);

            if (realEstate == null)
            {
                return Task.FromResult(false);
            }

            if (realEstate.RealEstateStatus == RealEstateStatus.Active)
            {
                request.request.RequestStatus = RequestStatus.Pending;
                var result = requestRepository.Create(request.request);

                return Task.FromResult(result != null);
            }

            return Task.FromResult(false);
        }
    }
}
