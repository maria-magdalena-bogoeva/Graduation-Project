using BulgariaApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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


    }
}
