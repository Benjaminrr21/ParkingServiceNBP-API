using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Infrastructure.SqlServer
{
    public class ParkDbContext : IdentityDbContext<ApplicationUser>
    {
        public ParkDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> Users { get; set; }
       /* public DbSet<Controllor> Controllors { get; set; }*/
        public DbSet<ParkingPlace> ParkingPlaces { get; set;}
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<SubscriptionCard> SubscriptionCards { get; set; }
        public DbSet<OneOffCard> OneOffCards { get; set; }
        public DbSet<Control> Controls { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            /*modelBuilder.Entity<ApplicationUser>().HasKey(u => u.UserId);
            modelBuilder.Entity<ApplicationUser>().Property(u => u.UserId).ValueGeneratedOnAdd();*/

            /*modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Controllor>().ToTable("Controllors");*/
        }


    }
}
