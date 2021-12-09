using IdentityService.BO;
using IdentityService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.BL
{
    public interface IUserBL
    {
        public UserBO Authenticate(string strUserName, string strPassword);
    }
}
