using EazzyRents.Application.Common.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Images.Commands
{
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, bool>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IImageRepository imageRepository;

        public CreateImageCommandHandler(IRealEstateRepository realEstateRepository, 
                                         IImageRepository imageRepository
            )
        {
            this.realEstateRepository = realEstateRepository;
            this.imageRepository = imageRepository;
        }
        public Task<bool> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            List<string> allUrls = new List<string>();
            var realEstate = this.realEstateRepository.GetById(request.RealEstateId);

            if (realEstate == null || request.ImageDataList == null)
            {
                return Task.FromResult(false);
            }

            realEstate.ImageUrls.Clear();

            foreach(var image in request.ImageDataList)
            {
                var imageList = this.imageRepository.UpdateImage(image, realEstate.Email);
                allUrls.Add(imageList.Url + "/" + imageList.FileName);
            }


            realEstate.ImageUrls.AddRange(allUrls);
            var res = this.realEstateRepository.Update(realEstate);

            return Task.FromResult(res);
        }
    }
}
