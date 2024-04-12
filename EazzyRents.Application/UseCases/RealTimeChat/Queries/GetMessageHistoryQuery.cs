using EazzyRents.Application.UseCases.RealTimeChat.Entities;
using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.RealTimeChat.Queries
{
    public class GetMessageHistoryQuery : IRequest<List<Message>>
    {
        public int UserId { get; set; }
    }
}
