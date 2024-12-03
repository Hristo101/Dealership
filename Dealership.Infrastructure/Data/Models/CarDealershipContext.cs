
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Infrastructure.Data.Configuration;

namespace Dealership.Infrastructure.Data.Models
{
    public class CarDealershipContext : IdentityDbContext<ApplicationUser>
    {
        public CarDealershipContext(DbContextOptions<CarDealershipContext> options)
          : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Announcement> Sales { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Dealership> Dealerships { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<CarDealership> CarDealerships { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
             .HasKey(cd => new { cd.DealershipId, cd.UserId });

            modelBuilder.Entity<Comment>()
          .HasOne(uc => uc.User)
          .WithMany(u => u.Comments)
          .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<Comment>()
                .HasOne(uc => uc.Dealership)
                .WithMany(c => c.Comments)
                .HasForeignKey(uc => uc.DealershipId);


            modelBuilder.Entity<CarDealership>()
                .HasKey(cd => new { cd.CarId, cd.DealershipId });

            modelBuilder.Entity<CarDealership>()
                .HasOne(cd => cd.Car)
                .WithMany(c => c.CarDealerships)
                .HasForeignKey(cd => cd.CarId);

            modelBuilder.Entity<CarDealership>()
                .HasOne(cd => cd.Dealership)
                .WithMany(d => d.CarDealerships)
                .HasForeignKey(cd => cd.DealershipId);

            modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
        }
    }

}

