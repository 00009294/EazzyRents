﻿using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using EazzyRents.Infrastructure.Data;

namespace EazzyRents.Infrastructure.Persistence
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private readonly AppDbContext appDbContext;

        public RealEstateRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public RealEstate Create(RealEstate realEstate)
        {
            this.appDbContext.RealEstates.Add(realEstate);
            this.appDbContext.SaveChanges();
            return realEstate;
        }

        public bool Delete(int id)
        {
            var realEstate = this.appDbContext.RealEstates.FirstOrDefault(r => r.Id == id);
            
            if (realEstate != null)
            {
                this.appDbContext.RealEstates.Remove(realEstate);
                return this.appDbContext.SaveChanges() > 0;
            }

            return false;
        }

        public List<RealEstate> GetAll()
        {
            return this.appDbContext.RealEstates.ToList();
        }

        public List<RealEstate> GetByAddress(Address address)
        {
            return this.appDbContext.RealEstates.Where(r => r.Address == address).ToList();
        }

        public RealEstate? GetById(int id)
        {
            return this.appDbContext.RealEstates.FirstOrDefault(r => r.Id == id);
        }

        public List<RealEstate> GetByName(string name)
        {
            return this.appDbContext.RealEstates.Where(r => r.Description.StartsWith(name)).ToList();
        }

        public List<RealEstate> GetOwnerIdByEmail(string email)
        {
            return this.appDbContext.RealEstates.Where(r => r.Email == email).ToList();
        }

        public List<RealEstate> GetByPrice(double fromPrice, double toPrice)
        {
            return this.appDbContext.RealEstates.Where(r => r.Price >= fromPrice && r.Price <= toPrice).ToList();
        }

        public bool Update(RealEstate realEstate)
        {
            if (realEstate != null)
            {
                this.appDbContext.Update(realEstate);
                return this.appDbContext.SaveChanges() > 0;
            }
            return false;
        }
    }
}
