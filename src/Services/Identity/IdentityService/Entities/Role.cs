using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Entities
{
    public class Role
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
