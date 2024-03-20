using EazzyRents.Core.Enums;

namespace EazzyRents.Core.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int RealEstateId { get; set; }
        public int LandlordId { get; set; }
        public double Price { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate
        {
            get => MoveOutDate;
            set
            {
                if (value > MoveInDate)
                {
                    MoveInDate = value;
                }
                else
                {
                    throw new ArgumentException("MoveOutDate must be higher than MoveInDate.");
                }
            }
        }
        public DateTime SubmittedDate { get; set; } = DateTime.UtcNow;
    }
}
