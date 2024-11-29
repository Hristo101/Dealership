using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Infrastructure.Models
{
        public class CarDealershipContext : IdentityDbContext<ApplicationUser>
        {
        public CarDealershipContext(DbContextOptions<CarDealershipContext> options)
          : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
            public DbSet<Sale> Sales { get; set; }
            public DbSet<Comment> Comments { get; set; }
            public DbSet<Dealership> Dealerships { get; set; }
            public DbSet<UserCar> UserCars { get; set; }
            public DbSet<CarDealership> CarDealerships { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCar>()
          .HasOne(uc => uc.User)
          .WithMany(u => u.UserCars)
          .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserCar>()
                .HasOne(uc => uc.Car)
                .WithMany(c => c.UserCars)
                .HasForeignKey(uc => uc.CarId);

            modelBuilder.Entity<CarDealership>()
                .HasKey(cd => new { cd.CarId, cd.DealershipId }); // Сложен първичен ключ

            modelBuilder.Entity<CarDealership>()
                .HasOne(cd => cd.Car)
                .WithMany(c => c.CarDealerships)
                .HasForeignKey(cd => cd.CarId);

            modelBuilder.Entity<CarDealership>()
                .HasOne(cd => cd.Dealership)
                .WithMany(d => d.CarDealerships)
                .HasForeignKey(cd => cd.DealershipId);
        }
    }

 }

