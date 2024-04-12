using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Hubs.Conversations.Commands
{
    public record CreateConversationCommand(Conversation conversation) : IRequest<bool>;
}
