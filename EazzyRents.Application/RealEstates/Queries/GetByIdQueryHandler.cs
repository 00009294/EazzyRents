using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.RealEstates.Queries
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, RealEstate>
    {
        private readonly IRealEstateRepository realEstateRepository;

        public GetByIdQueryHandler(IRealEstateRepository realEstateRepository)
        {
            this.realEstateRepository = realEstateRepository;
        }
        public Task<RealEstate?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.realEstateRepository.GetById(request.id));
        }
    }
}
