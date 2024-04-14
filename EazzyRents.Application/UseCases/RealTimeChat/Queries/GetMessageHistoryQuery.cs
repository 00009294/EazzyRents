using EazzyRents.Application.UseCases.RealTimeChat.Entities;
using MediatR;

namespace EazzyRents.Application.UseCases.RealTimeChat.Queries
{
    public class GetMessageHistoryQuery : IRequest<List<Message>>
    {
        public int UserId { get; set; }
    }
}
