using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Queries
{
    public class GetByPriceQueryHandler : IRequestHandler<GetByPriceQuery, List<RealEstate>>
    {
        private readonly IRealEstateRepository realEstateRepository;

        public GetByPriceQueryHandler(IRealEstateRepository realEstateRepository)
        {
            this.realEstateRepository = realEstateRepository;
        }

        public Task<List<RealEstate>> Handle(GetByPriceQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.realEstateRepository.GetByPrice(request.price));
        }
    }
}
