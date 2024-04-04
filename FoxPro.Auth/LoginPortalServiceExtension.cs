using FoxPro.Auth.Entities;
using FoxPro.Auth.Reposititory;
using FoxPro.Auth.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxPro.Auth
{
    public static class LoginPortalServiceExtension
    {
        public static IServiceCollection AddIdentityAndJwtServices<TContext, TUser>(this IServiceCollection services,
            IConfiguration configuration) where TContext : DbContext where TUser : ApplicationUser
        {
            services.AddIdentity<TUser, ApplicationRoles>()
                    .AddEntityFrameworkStores<TContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<ILoginRepository<TUser>, LoginRepository<TUser>>();
            services.AddScoped<IAccountService<TUser>, AccountService<TUser>>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {

                x.SaveToken = true;
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,

                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });

            return services;
        }

        // This method is created to seed initial data in our table with hashed  password.
        public static void SeedUserWithHashedPassword<T>(ModelBuilder builder, T user, string password) where T : ApplicationUser
        {
            PasswordHasher<T> passwordHasher = new PasswordHasher<T>();
            var hashedPassword = passwordHasher.HashPassword(user, password);

            if (user != null)
            {
                user.PasswordHash = hashedPassword;
                builder.Entity<T>().HasData(user);
            }
        }
    }
}
