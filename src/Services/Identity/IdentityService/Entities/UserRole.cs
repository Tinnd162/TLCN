using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Entities
{
    public class UserRole
    {
        public string UserID { get; set; }
        public string RoleID { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
