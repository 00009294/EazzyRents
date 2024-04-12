using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Application.UseCases.RealTimeChat.Entities;
using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
