
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
        public DbSet<Query> Queries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
             .HasKey(cd => new { cd.UserId });

            modelBuilder.Entity<Comment>()
          .HasOne(uc => uc.User)
          .WithMany(u => u.Comments)
          .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserFavoriteAnnouncement>()
                .HasKey(ufa => new { ufa.AnnouncementId, ufa.UserId });

            modelBuilder.Entity<UserFavoriteAnnouncement>()
        .HasOne(uc => uc.User)
        .WithMany(u => u.FavoriteAnnouncements)
        .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserFavoriteAnnouncement>()
    .HasOne(uc => uc.Announcement)
    .WithMany(u => u.FavoriteUsers)
    .HasForeignKey(uc => uc.AnnouncementId);

            modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
        }
    }

}

