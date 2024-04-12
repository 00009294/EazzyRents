using EazzyRents.Application.Common.Interfaces.Persistence;
using MediatR;

namespace EazzyRents.Application.UseCases.Hubs.Conversations.Commands
{
    public class DeleteConversationCommandHandler : IRequestHandler<DeleteConversationCommand, bool>
    {
        private readonly IConversationRepository conversationRepository;
        private readonly IChatMessageRepository chatMessageRepository;

        public DeleteConversationCommandHandler(
            IConversationRepository conversationRepository,
            IChatMessageRepository chatMessageRepository)
        {
            this.conversationRepository = conversationRepository;
            this.chatMessageRepository = chatMessageRepository;
        }
        public Task<bool> Handle(DeleteConversationCommand request, CancellationToken cancellationToken)
        {
            var conversation = this.conversationRepository.GetAll(request.conversationId);

            //this.conversationRepository.Remove()
            return Task.FromResult(true);
        }
    }
}
