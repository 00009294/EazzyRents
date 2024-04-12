using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Hubs.Conversations.Commands
{
    public record CreateConversationCommand(Conversation conversation) : IRequest<bool>;
}
