using EazzyRents.Core.Enums;

namespace EazzyRents.Core.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public int UserRole { get; set; }
        public int RealEstateId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
