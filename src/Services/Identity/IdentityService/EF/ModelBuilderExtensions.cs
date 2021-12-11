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
            string userID = Guid.NewGuid().ToString();
            string customerID = Guid.NewGuid().ToString();
            string roleID = Guid.NewGuid().ToString();
            string roleCustomerID = Guid.NewGuid().ToString();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                   UserID = userID,
                   UserName = "Viet",
                   Password = "12345"
                },
                new User
                {
                   UserID = customerID,
                   UserName = "Customer",
                   Password = "12345"
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
