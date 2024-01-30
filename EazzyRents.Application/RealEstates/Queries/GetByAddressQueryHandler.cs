using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Queries
{
      public class GetByAddressQueryHandler : IRequestHandler<GetByAddressQuery, List<RealEstate>>
      {
            private readonly IRealEstateRepository realEstateRepository;

            public GetByAddressQueryHandler (IRealEstateRepository realEstateRepository)
            {
                  this.realEstateRepository = realEstateRepository;
            }
            public Task<List<RealEstate>> Handle (GetByAddressQuery request, CancellationToken cancellationToken)
            {
                  return Task.FromResult(this.realEstateRepository.GetByAddress(request.address));
            }
      }
}
