using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IRealEstateRepository
    {
        List<RealEstate> GetAll();
        RealEstate? GetById(int id);
        List<RealEstate> GetByName(string name);
        RealEstate Create(RealEstate realEstate);
        bool Update(RealEstate realEstate);
        bool Delete(int id);
        List<RealEstate> GetByAddress(Address address);
        List<RealEstate> GetByPrice(double fromPrice, double toPrice);
    }
}
