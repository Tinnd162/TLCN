using IdentityService.BO;
using IdentityService.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.DA
{
    public class UserDA
    {
        public readonly IdentityDbContext _context;
        public UserDA(IdentityDbContext _context)
        {
            this._context = _context;
        }

        public UserBO Authenticate(string strUserName, string strPassword)
        {
           var userInfo =  _context.Users.Where(x => x.UserName == strUserName && x.Password == strPassword).FirstOrDefault();
            if(userInfo != null)
            {
                var objUserBO = new UserBO
                {
                    UserID = userInfo.UserID,
                    UserName = userInfo.UserName,
                    Password = userInfo.Password
                };
                return objUserBO;
            }
            return null;
        }
    }
}
