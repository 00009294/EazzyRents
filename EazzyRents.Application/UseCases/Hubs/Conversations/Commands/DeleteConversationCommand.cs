using MediatR;

namespace EazzyRents.Application.UseCases.Hubs.Conversations.Commands
{
    public record DeleteConversationCommand(int conversationId) : IRequest<bool>;
}
