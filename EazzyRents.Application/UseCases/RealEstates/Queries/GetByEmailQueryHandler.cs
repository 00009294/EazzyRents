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
    public class GetByEmailQueryHandler : IRequestHandler<GetByEmailQuery, List<RealEstate>>
    {
        private readonly IRealEstateRepository realEstateRepository;

        public GetByEmailQueryHandler(IRealEstateRepository realEstateRepository)
        {
            this.realEstateRepository = realEstateRepository;
        }
        public Task<List<RealEstate>> Handle(GetByEmailQuery request, CancellationToken cancellationToken)
        {
            var allSelectedRealEstates = this.realEstateRepository
                .GetAll().Where(r => r.Email == request.email).ToList();


            return Task.FromResult(allSelectedRealEstates);
        }
    }
}
