using EazzyRents.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Authentication.Common
{
    public record AuthResult
    (
        User User,
        string Token
        );
}
