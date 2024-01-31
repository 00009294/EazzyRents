using AutoMapper;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Application.Common.Interfaces.Services;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Commands
{
      public class CreateCommandHandler : IRequestHandler<CreateCommand, bool>
      {
            private readonly IRealEstateRepository realEstateRepository;
            private readonly IMapper mapper;
            private readonly IBlobService blobService;

            public CreateCommandHandler (IRealEstateRepository realEstateRepository,
                IBlobService blobService,
                IMapper mapper)
            {
                  this.realEstateRepository = realEstateRepository;
                  this.mapper = mapper;
                  this.blobService = blobService;
            }

            public async Task<bool> Handle (CreateCommand request, CancellationToken cancellationToken)
             {
                  var realEstate = this.mapper.Map<RealEstate>(request);
                  if (realEstate == null) return false;
                  
                  foreach (var image in request.Images)
                  {
                        await this.blobService.UploadBlobFileAsync(image);
                  }

                  return this.realEstateRepository.Create(realEstate);
            }
      }
}
