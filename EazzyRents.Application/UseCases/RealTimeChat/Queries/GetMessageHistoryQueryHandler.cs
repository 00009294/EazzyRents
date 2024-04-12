using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Application.UseCases.RealTimeChat.Entities;
using MediatR;

namespace EazzyRents.Application.UseCases.RealTimeChat.Queries
{
    public class GetMessageHistoryQueryHandler : IRequestHandler<GetMessageHistoryQuery, List<Message>>
    {
        private readonly IChatMessageRepository messageRepository;

        public GetMessageHistoryQueryHandler(IChatMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }
        public Task<List<Message>> Handle(GetMessageHistoryQuery request, CancellationToken cancellationToken)
        {
            //var allMessages = this.messageRepository.GetAll(request.UserId);

            return Task.FromResult(new List<Message>());
        }
    }
}
