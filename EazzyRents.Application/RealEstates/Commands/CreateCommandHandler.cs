using AutoMapper;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Application.Common.Interfaces.Services;
using EazzyRents.Application.Common.Options;
using EazzyRents.Application.Helper.Dtos;
using EazzyRents.Core.Models;
using MediatR;
using Microsoft.Extensions.Options;

namespace EazzyRents.Application.RealEstates.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, bool>
    {
        private readonly IRealEstateRepository realEstateRepository;
        private readonly IMapper mapper;
        private readonly IBlobService blobService;
        private readonly AzureBlobStorageOptions azureBlobStorageOptions;

        public CreateCommandHandler(IRealEstateRepository realEstateRepository, 
            IOptions<AzureBlobStorageOptions> azureBlobStorageOptions,
            IBlobService blobService,
            IMapper mapper)
        {
            this.realEstateRepository = realEstateRepository;
            this.mapper = mapper;
            this.blobService = blobService;
            this.azureBlobStorageOptions = azureBlobStorageOptions.Value;
        }

        public async Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var realEstate = this.mapper.Map<RealEstate>(request);
            var createdRealEstate = this.realEstateRepository.Create(realEstate);
            
            var createdPhotos = new List<FileDto>();
            if (request.Images != null)
            {
                var folderName = Guid.NewGuid().ToString();
                var photosPath = $"{this.azureBlobStorageOptions.PhotosFolderName}/{folderName}";

                foreach (var photo in request.Images)
                {
                    await this.blobService.UploadFileBlobAsync(photo, photosPath);
                    var file = new Core.Models.File
                    {
                        FileName = photo.FileName,
                        Path = photosPath,
                        RealEstateId = realEstate.Id
                    };
                    //var res = await _fileRepository.AddAsync(file);
                    //createdPhotos.Add(this.mapper.Map<FileDto>(res));
                    //return Task.FromResult());
                }
            }
            return true;
        }
    }
}
