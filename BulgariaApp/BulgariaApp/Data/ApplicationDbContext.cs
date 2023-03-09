using BulgariaApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BulgariaApp.Models.Excursion;
using BulgariaApp.Models.Attraction;

namespace BulgariaApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Excursion> Excursions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<BulgariaApp.Models.Excursion.ExcursionCreateVM> ExcursionCreateVM { get; set; }
        public DbSet<BulgariaApp.Models.Attraction.AttractionCreateVM> AttractionCreateVM { get; set; }
        public DbSet<BulgariaApp.Models.Attraction.AttractionIndexVM> AttractionIndexVM { get; set; }
        public DbSet<BulgariaApp.Models.Attraction.AttractionEditVM> AttractionEditVM { get; set; }
        public DbSet<BulgariaApp.Models.Attraction.AttractionDeleteVM> AttractionDeleteVM { get; set; }
        public DbSet<BulgariaApp.Models.Attraction.AttractionDetailsVM> AttractionDetailsVM { get; set; }
        public DbSet<BulgariaApp.Models.Excursion.ExcursionIndexVM> ExcursionIndexVM { get; set; }
        public DbSet<BulgariaApp.Models.Excursion.ExcursionEditVM> ExcursionEditVM { get; set; }
        public DbSet<BulgariaApp.Models.Excursion.ExcursionDetailsVM> ExcursionDetailsVM { get; set; }
        public DbSet<BulgariaApp.Models.Excursion.ExcursionDeleteVM> ExcursionDeleteVM { get; set; }


    }
}
