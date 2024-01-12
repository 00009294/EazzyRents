using AutoMapper;
using EazzyRents.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Helper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<RealEstate, TaskCreationOptions>().ReverseMap();
        }
    }
}
