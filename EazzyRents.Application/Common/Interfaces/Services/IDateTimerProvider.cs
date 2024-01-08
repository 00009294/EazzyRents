using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Common.Interfaces.Services
{
    public interface IDateTimerProvider
    {
        DateTime UtcNow { get; }
    }
}
