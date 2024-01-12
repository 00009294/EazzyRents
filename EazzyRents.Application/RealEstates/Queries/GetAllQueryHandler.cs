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
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<RealEstate>>
    {
        private readonly IRealEstateRepository realEstateRepository;

        public GetAllQueryHandler(IRealEstateRepository realEstateRepository)
        {
            this.realEstateRepository = realEstateRepository;
        }
        public Task<List<RealEstate>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.realEstateRepository.GetAll());
        }
    }
}
