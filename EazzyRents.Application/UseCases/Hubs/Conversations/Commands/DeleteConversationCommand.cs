using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Hubs.Conversations.Commands
{
    public record DeleteConversationCommand(int conversationId) : IRequest<bool>;
}
