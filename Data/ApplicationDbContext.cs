using System;
using System.Collections.Generic;
using System.Text;
using GoodTimes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace GoodTimes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<menukaart>()
                .HasMany(b => b.categories);

            modelBuilder.Entity<categorie>()
                .HasOne(k => k.menukaart);

            modelBuilder.Entity<categorie>()
                .HasMany(b => b.products);

            modelBuilder.Entity<product>()
                .HasOne(k => k.categorie);
        }

        public DbSet<GoodTimes.Models.reservering> reservering { get; set; }
        public DbSet<GoodTimes.Models.menukaart> menukaart { get; set; }
        public DbSet<GoodTimes.Models.categorie> categorie { get; set; }
        public DbSet<GoodTimes.Models.product> product { get; set; }
        public DbSet<GoodTimes.Models.bestelling> bestelling { get; set; }
    }


}
