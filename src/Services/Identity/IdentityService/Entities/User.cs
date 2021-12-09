using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Entities
{
    public class User
    {
        public string UserID { get; set; }
        public string  UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Password{ get; set; }
        public string Address { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
