using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Landlord.Commands
{
    public class UpdateRequestStatusCommand : IRequest<Request>
    {
        public int RequestId { get; set; }
        public RequestStatus RequestStatus { get; set; }

        public UpdateRequestStatusCommand(int requestId, RequestStatus requestStatus)
        {
            RequestId = requestId;
            RequestStatus = requestStatus;
        }
    }
}
