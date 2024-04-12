using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RealEstates.Commands
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IImageRepository imageRepository;

        public UpdateCommandHandler(IRealEstateRepository realEstateRepository,
            IImageRepository imageRepository)
        {
            this.realEstateRepository = realEstateRepository;
            this.imageRepository = imageRepository;
        }
        public Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var oldRealEstate = this.realEstateRepository.GetById(request.Id);
            
            if (oldRealEstate == null) return Task.FromResult(false);

            var realEstate = new RealEstate()
            {
                Id = request.Id,
                Description = request.Descriprion,
                Address = request.Address,
                Price = request.Price,
                Email = oldRealEstate.Email,
                PhoneNumber = request.PhoneNumber,
                RealEstateStatus = request.Status,
                ImageUrls = new List<string>()
            };

            List<string> imageDataList = new List<string>();

            if (request.Images != null)
            {
                foreach (var image in request.Images)
                {
                    var imageList = imageRepository.UpdateImage(image, oldRealEstate.Email);
                    imageDataList.Add(imageList.Url + "/" + imageList.FileName);
                }

                realEstate.ImageUrls = imageDataList;
            }


            return Task.FromResult(realEstateRepository.Update(realEstate));
        }
    }
}
