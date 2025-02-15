﻿using AdminWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWebApp.Services
{
    public interface IIdentityService
    {
        Task<UserModel> Authenticate(UserModel objUser);
    }
}
