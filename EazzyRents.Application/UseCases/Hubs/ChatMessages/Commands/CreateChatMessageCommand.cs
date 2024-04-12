using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Hubs.ChatMessages.Commands
{
    public class CreateChatMessageCommand : IRequest<bool>
    {
        public int ConversationId { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
    }
}
