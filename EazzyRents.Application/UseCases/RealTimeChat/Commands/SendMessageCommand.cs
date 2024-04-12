using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.RealTimeChat.Commands
{
    public class SendMessageCommand : IRequest<bool>
    {
        public User User {  get; set; }
        public string Message { get; set; }
    }
}
