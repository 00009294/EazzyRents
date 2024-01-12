using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.RealEstates.Commands
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
    {
        private readonly IRealEstateRepository realEstateRepository;

        public UpdateCommandHandler(IRealEstateRepository realEstateRepository)
        {
            this.realEstateRepository = realEstateRepository;
        }
        public Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var realEstate = new RealEstate()
            {
                Id = request.Id,
                Description = request.Descriprion,
                Address = request.Address,
                Price = request.Price,
                Photo = request.Photo,
                PhoneNumber = request.PhoneNumber,
                RealEstateStatus = request.Status
            };
            return Task.FromResult(this.realEstateRepository.Update(realEstate));
        }
    }
}
