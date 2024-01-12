using EazzyRents.Application.RealEstates.Entities;
using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.RealEstates.Commands
{
    public class CreateCommand : IRequest<bool>
    {
        public CreateCommandEntity Entity { get; set; }
    }

}
