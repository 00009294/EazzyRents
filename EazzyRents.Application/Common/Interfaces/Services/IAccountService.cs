using EazzyRents.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Common.Interfaces.Services
{
    public interface IAccountService
    {
        Task SendConfirmationEmail(string email, string subject, string message);
    }
}
