using EazzyRents.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Chats.Commands
{
    public class CreateMessageCommand : IRequest<bool>
    {
        public string Content { get; set; }
        public int UserRole { get; set; }
        public int RealEstateId {  get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
