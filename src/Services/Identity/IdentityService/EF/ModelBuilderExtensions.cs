using IdentityService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.EF
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            string userID = "61cea2f03d7ec05a7321745d";
            string customerID = "61cea2f375e10dd236f9de06";
            string roleID = "61cea2fbcb8af21f87c2eb0c";
            string roleCustomerID = "61cea30163e98302a5ec0a12";
            modelBuilder.Entity<User>().HasData(
                new User
                {
                   UserID = userID,
                   UserName = "Admin",
                   Password = "******"
                },
                new User
                {
                   UserID = customerID,
                   UserName = "Customer",
                   Password = "*****"
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleID = roleID,
                    RoleName = "admin"
                },
                new Role
                {
                    RoleID = roleCustomerID,
                    RoleName = "customer"
                }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserID = userID,
                    RoleID = roleID
                },
                new UserRole
                {
                    UserID = customerID,
                    RoleID = roleCustomerID
                }
            );
        }
    }
}
