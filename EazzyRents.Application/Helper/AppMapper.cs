using AutoMapper;
using EazzyRents.Application.RealEstates.Commands;
using EazzyRents.Core.Models;
using EazzyRents.Core.Models.BlobStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace EazzyRents.Application.Helper
{
      public class AppMapper : Profile
      {
            public AppMapper ()
            {
                  CreateMap<RealEstate, CreateCommand>().ReverseMap();
                  //CreateMap<IFormFile, BlobContent>().ReverseMap();
            }
      }
}
