﻿using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.RealEstates.Queries
{
    public record GetByAddressQuery(string address) : IRequest<List<RealEstate>>;
    
}
