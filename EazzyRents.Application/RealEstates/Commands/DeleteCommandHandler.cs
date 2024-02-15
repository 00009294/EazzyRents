using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Application.Common.Interfaces.Services;
using MediatR;

namespace EazzyRents.Application.RealEstates.Commands
{
      public class DeleteCommandHandler : IRequestHandler<DeleteCommand,bool>
      {
            private readonly IRealEstateRepository realEstateRepository;
            private readonly IBlobService blobService;

            public DeleteCommandHandler(IRealEstateRepository realEstateRepository,IBlobService blobService)
            {
                  this.realEstateRepository = realEstateRepository;
                  this.blobService = blobService;
            }
            public Task<bool> Handle(DeleteCommand request,CancellationToken cancellationToken)
            {
                  var realEstate = this.realEstateRepository.GetById(request.id);
                  //foreach(var image in realEstate.Images)
                  //{
                  //      //this.blobService.DeleteBlobFile(image.ToString());
                  //}

                  return Task.FromResult(this.realEstateRepository.Delete(request.id));
            }
      }
}
