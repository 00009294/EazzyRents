using EazzyRents.Application.Common.Interfaces.Persistence;
using MediatR;

namespace EazzyRents.Application.UseCases.RealTimeChat.Commands
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, bool>
    {
        private readonly IChatMessageRepository messageRepository;

        public SendMessageCommandHandler(IChatMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }
        public Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            //var message = new Message
            //{
            //    User = request.User,
            //    Content = request.Message,
            //    Timestamp = DateTime.UtcNow
            //};

            //var result = this.messageRepository.Add(message);

            //return Task.FromResult(result);
            return Task.FromResult(true);
        }
    }
}
