using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.RealEstates.Entities
{
    public class CreateCommandEntity
    {
        public int Id { get; init; }
        public string Description { get; init; }
        public string Address { get; init; }
        public double Price { get; init; }
        public byte[] Photo { get; init; }
        public string PhoneNumber { get; init; }
        public User OwnerId { get; init; }
        public RealEstateStatus RealEstateStatus { get; init; }
    }
}
