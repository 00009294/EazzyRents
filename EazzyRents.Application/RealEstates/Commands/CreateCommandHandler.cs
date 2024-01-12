using AutoMapper;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, bool>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IMapper mapper;

        public CreateCommandHandler(IRealEstateRepository realEstateRepository, IMapper mapper)
        {
            this.realEstateRepository = realEstateRepository;
            this.mapper = mapper;
        }

        public Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var realEstate = this.mapper.Map<RealEstate>(request);

            return Task.FromResult(this.realEstateRepository.Create(realEstate));
        }
    }
}
