using FoxPro.Auth;
using FoxPro.Auth.Data;
using FoxPro.Auth.Entities;
using FoxPro.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            User admin = new User()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                Name = "Admin",
                Email = "admin@gmail.com",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
            };

            LoginPortalServiceExtension.SeedUserWithHashedPassword<User>(builder, admin, "Admin@123");
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<ApplicationRoles>().HasData(
                new ApplicationRoles() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new ApplicationRoles() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "HR", ConcurrencyStamp = "2", NormalizedName = "HR" },
                new ApplicationRoles() { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Manager", ConcurrencyStamp = "3", NormalizedName = "MANAGER" },
                new ApplicationRoles() { Id = "d230453f-bcd0-4742-80ea-9ce858ff37d7", Name = "Developer", ConcurrencyStamp = "4", NormalizedName = "DEVELOPER" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserRole>().HasData(
              new ApplicationUserRole() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
            );
        }
    }
}