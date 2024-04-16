﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Images.Queries
{
    public record GetAllQuery() : IRequest<List<string>>;
}