﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Authentication.Common
{
    public record AuthResultForRegistration(
        bool IsRegistered,
        string Message
        );
}
