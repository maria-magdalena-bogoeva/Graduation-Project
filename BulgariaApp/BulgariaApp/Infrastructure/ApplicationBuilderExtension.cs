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

            var dataAttraction = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedAttraction(dataAttraction);

            return app;
        }

        private static void SeedAttraction(ApplicationDbContext dataAttraction)
        {
            if (dataAttraction.Attractions.Any())
            {
                return;
            }
            dataAttraction.Attractions.AddRange(new[]
            {

                new Attraction{AttractionName="Madara Horseman" },
                new Attraction{AttractionName="Rila Monastery" },
                new Attraction{AttractionName="the Krakra fortress" },
                new Attraction{AttractionName="Krushun waterfall" },
                new Attraction{AttractionName="The Rocks of Belogradchik" },
                new Attraction{AttractionName="Thorn Gorge" },
                new Attraction{AttractionName="The seven Rila lakes" },
                new Attraction{AttractionName="The paradise splash waterfall" },
                new Attraction{AttractionName="Devil's Throat Cave" },
                new Attraction{AttractionName="Black Sea" },
                new Attraction{AttractionName="Borovets" },
                new Attraction{AttractionName="Vihren peak" },
                new Attraction{AttractionName="Musala peak" },
                new Attraction{AttractionName="Slavei hut" },
                new Attraction{AttractionName="Srebarna Nature Reserve" },
                new Attraction{AttractionName="Holy Forty Martyrs Church "},
            });
            dataAttraction.SaveChanges();
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
