using EazzyRents.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimerProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
