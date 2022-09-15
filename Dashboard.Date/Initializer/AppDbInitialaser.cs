using Dashboard.Data.Data.Context;
using Dashboard.Data.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Data.Initializer
{
    public class AppDbInitialaser
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScoupe = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScoupe.ServiceProvider.GetService<AppDbContext>();

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Microsoft.AspNetCore.Identity.IdentityRole()
                        {
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                    await context.SaveChangesAsync();
                }
                if (!context.Users.Any())
                {
                    var user = new AppUser()
                    {
                        Email = "admin@gmail.com",
                        NormalizedEmail = "ADMIN@GMAIL.COM",
                        UserName = "admin@gmail.com",
                        NormalizedUserName = "ADMIN@GMAIL.COM",
                        EmailConfirmed = true,
                        Name = "Admin",
                        Surname = "Admin",
                        Address = "Address is a privatical!!!"
                    };
                    var password = new PasswordHasher<AppUser>();
                    var hashed = password.HashPassword(user, "Qwerty-1");
                    user.PasswordHash = hashed;

                    context.Users.AddRange(user);

                    await context.SaveChangesAsync();

                    UserManager<AppUser> manager = serviceScoupe.ServiceProvider.GetService<UserManager<AppUser>>();
                    await manager.AddToRoleAsync(user, "Administrator");                   
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
