using BulgariaApp.Data;
using BulgariaApp.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulgariaApp.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataCategory = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);

          

            return app;
        }

       

        private static void SeedCategories(ApplicationDbContext dataCategory)
        {
            if (dataCategory.Categories.Any())
            {
                return;
            }
            dataCategory.Categories.AddRange(new[]
            {
                new Category{CategoryName="Monument" },
                new Category{CategoryName="Museum" },
                new Category{CategoryName="Mountain" },
                new Category{CategoryName="Art Gallery" },
                new Category{CategoryName="Ski Holiday" },
                new Category{CategoryName="Beach Holiday" },
                new Category{CategoryName="Cave" },
                new Category{CategoryName="Lake" },
                new Category{CategoryName="Natural Resort" },
                new Category{CategoryName="Waterfall" },
                new Category{CategoryName="Nature Reserve" },
                new Category{CategoryName="Fortress" },
                new Category{CategoryName="Church" },

            });
            dataCategory.SaveChanges();
        }

        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Administrator", "Client" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.PhoneNumber = "0888888888";
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                var result = await userManager.CreateAsync(user, "123456");
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}
