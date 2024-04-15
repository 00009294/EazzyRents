using EazzyRents.Application.Common.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Images.Queries
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, List<string>>
    {
        private readonly IRealEstateRepository realEstateRepository;

        public GetByIdQueryHandler(IRealEstateRepository realEstateRepository)
        {
            this.realEstateRepository = realEstateRepository;
        }
        public Task<List<string>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var allImages = this.realEstateRepository.GetAll().Where(r => r.Id == request.id);

            foreach(var image in allImages)
            {
                return Task.FromResult(image.ImageUrls);
            }

            return Task.FromResult(new List<string>());
        }
    }
}
