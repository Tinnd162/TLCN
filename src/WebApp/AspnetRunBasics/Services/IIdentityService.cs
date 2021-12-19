using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public interface IIdentityService
    {
         Task<UserModel> Authenticate(UserModel objUser);
    }
}
