using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Application.RealEstates.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.RealEstates.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, bool>
    {
        private readonly IRealEstateRepository realEstateRepository;

        public CreateCommandHandler(IRealEstateRepository realEstateRepository)
        {
            this.realEstateRepository = realEstateRepository;
        } 
        
        public Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var realEstate = new Core.Models.RealEstate()
            {
                Id = request.Id,
                Description = request.Descriprion,
                Address = request.Address,
                Price = request.Price,
                PhoneNumber = request.PhoneNumber,
                OwnerId = request.OwnerId,
                RealEstateStatus = request.Status
            };

           return Task.FromResult(this.realEstateRepository.Create(realEstate));
        }
    }
}
