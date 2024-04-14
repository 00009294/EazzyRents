namespace EazzyRents.Core.Models
{
    public class BaseAuditableEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
