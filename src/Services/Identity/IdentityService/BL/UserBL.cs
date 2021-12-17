using IdentityModel.Client;
using IdentityService.BO;
using IdentityService.DA;
using IdentityService.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityService.BL
{
    public class UserBL : IUserBL
    {
        private readonly IdentityDbContext _context;
        public UserBL(IdentityDbContext _context)
        {
            this._context = _context;
        }
        public UserBO Authenticate(string strUserName, string strPassword)
        {
            try
            {
                UserDA objUserDA = new UserDA(_context);
                var objUserBO = objUserDA.Authenticate(strUserName, strPassword);
                return objUserBO;
            }
            catch(Exception objEx)
            {
                return null;
            }
        }
    }
}
