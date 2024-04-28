using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Images.Commands
{
    public class CreateImageCommand : IRequest<bool>
    {
        public int RealEstateId { get; set; }
        public List<IFormFile> ImageDataList { get; set; }
    }
}
