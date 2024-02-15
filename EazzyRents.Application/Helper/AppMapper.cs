using AutoMapper;
using EazzyRents.Application.RealEstates.Commands;
using EazzyRents.Core.Models;

namespace EazzyRents.Application.Helper
{
      public class AppMapper : Profile
      {
            public AppMapper()
            {
                  CreateMap<RealEstate,CreateCommand>().ReverseMap();
                  //CreateMap<IFormFile, BlobContent>().ReverseMap();
            }
      }
}
