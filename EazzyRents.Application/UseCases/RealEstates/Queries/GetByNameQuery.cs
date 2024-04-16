using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.RealEstates.Queries
{
    public record GetByNameQuery(string name) : IRequest<List<RealEstate>>;
}
