using EazzyRents.Application.Common.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Images.Queries
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<string>>
    {
        private readonly IRealEstateRepository realEstateRepository;

        public GetAllQueryHandler(IRealEstateRepository realEstateRepository)
        {
            this.realEstateRepository = realEstateRepository;
        }
        public Task<List<string>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            List<string> temp = new List<string>();
            var res = this.realEstateRepository.GetAll();

            foreach(var item in res)
            {
                if (item.ImageUrls != null && item.ImageUrls.Any())
                {
                    temp.Add(item.ImageUrls.First()); 
                }
            }
            
            return Task.FromResult(temp);


        }
    }
}
