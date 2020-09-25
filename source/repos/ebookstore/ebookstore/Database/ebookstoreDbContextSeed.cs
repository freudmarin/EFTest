
using ebookstore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore
{

    public static class ebookstoreDbContextSeed
    {



        public static IApplicationBuilder UseDatabaseMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ebookDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ebookstoreUser>>();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                



      
                Task.Run(async () =>
                    {
                        var roleName = "Admin";

                        var roleExits = await roleManager.RoleExistsAsync(roleName);

                        if (!roleExits)
                        {
                            var result = await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = roleName
                            });
                        }

                        var adminUser = await userManager.FindByNameAsync(roleName);

                        if (adminUser == null)
                        {
                            adminUser = new ebookstoreUser
                            {
                                FirstName = "Administrator",
                                LastName = "Administrator",

                                Email = "admin@social.com",
                                UserName = roleName,//Admin

                            };

                            await userManager.CreateAsync(adminUser, "admin123");

                            await userManager.AddToRoleAsync(adminUser, roleName);
                        }
                    })
                    .GetAwaiter()
                    .GetResult();
                }
                return app;
            }
        }
    }

    
