using Microsoft.AspNetCore.SignalR;

namespace EazzyRents.Application.Chat
{
    public class AuctionHub : Hub
    {
        public async Task JoinLotGroup(int realEstateId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, realEstateId.ToString());
        }

        public async Task LeaveLotGroup(int realEstateId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, realEstateId.ToString());
        }

        public async Task JoinConversationGroup(int conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId.ToString());
        }

        public async Task LeaveConversationGroup(int conversationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId.ToString());
        }
    }
}
