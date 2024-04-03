using FoxPro.Auth;
using FoxPro.Auth.Data;
using FoxPro.Auth.Entities;
using FoxPro.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxPro.Data.Data
{
    public class ApplicationDbContext : LoginPortalDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);
        }
        private void SeedUsers(ModelBuilder builder)
        {

            User user = new User();
            

            LoginPortalServiceExtension.SeedUserWithHashedPassword<User>(builder, user, "User@123");
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<ApplicationRoles>().HasData(
                new ApplicationRoles() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new ApplicationRoles() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserRole>().HasData(
              new ApplicationUserRole() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
              new ApplicationUserRole() { RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330", UserId = "F7A13C3E-EB62-4193-9653-CB3BB571DADF" }
            );
        }
    }
}
