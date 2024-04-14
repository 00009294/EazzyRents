using EazzyRents.Application.Common.Interfaces.Persistence;
using MediatR;

namespace EazzyRents.Application.UseCases.Hubs.ChatMessages.Commands
{
    public class CreateChatMessageCommandHandler : IRequestHandler<CreateChatMessageCommand, bool>
    {
        private readonly IChatMessageRepository chatMessageRepository;
        private readonly IUserRepository userRepository;

        public CreateChatMessageCommandHandler(
            IChatMessageRepository chatMessageRepository,
            IUserRepository userRepository)
        {
            this.chatMessageRepository = chatMessageRepository;
            this.userRepository = userRepository;
        }
        public Task<bool> Handle(CreateChatMessageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
