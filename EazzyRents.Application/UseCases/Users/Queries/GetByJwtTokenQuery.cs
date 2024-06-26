﻿using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Users.Queries
{
    public record GetByJwtTokenQuery(string jwtToken) : IRequest<User>
    {
    }
}
