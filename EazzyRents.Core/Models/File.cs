namespace EazzyRents.Core.Models
{
    public class File
    {
        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }

        public string FileName { get; set; }

        public string Path { get; set; }
    }
}
