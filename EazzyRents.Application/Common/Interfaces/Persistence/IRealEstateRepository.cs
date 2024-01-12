using EazzyRents.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IRealEstateRepository
    {
        List<RealEstate> GetAll();
        RealEstate? GetById(int id);
        bool Create(RealEstate realEstate);
        bool Update(RealEstate realEstate);
        bool Delete(int id);
        List<RealEstate> GetByAddress(string address);
        List<RealEstate> GetByPrice(double price);
    }
}
