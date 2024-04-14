using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RealTimeChat.Commands
{
    public class SendMessageCommand : IRequest<bool>
    {
        public User User { get; set; }
        public string Message { get; set; }
    }
}
