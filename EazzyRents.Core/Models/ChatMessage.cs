namespace EazzyRents.Core.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public virtual User Sender { get; set; }
        public int ConversationId { get; set; }
        public virtual Conversation Conversation { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
