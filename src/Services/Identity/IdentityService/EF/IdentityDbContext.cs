using IdentityService.Configurations;
using IdentityService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.EF
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected IdentityDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.Seed();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
