namespace EazzyRents.Core.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public User Tenant { get; set; }
        public int LandlordId { get; set; }
        public User User { get; set; }
        public int RealEstateId { get; set; }
        public virtual RealEstate RealEstate { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
