using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public class GetByNameQueryHandler : IRequestHandler<GetByNameQuery, List<RealEstate>>
    {
        private readonly IRealEstateRepository realEstateRepository;

        public GetByNameQueryHandler(IRealEstateRepository realEstateRepository)
        {
            this.realEstateRepository = realEstateRepository;
        }
        public Task<List<RealEstate>> Handle(GetByNameQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.realEstateRepository.GetByName(request.name));
        }
    }
}
