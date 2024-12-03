using Dealership.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Infrastructure.Data.Configuration
{
    internal class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasData(SeedAnnouncement());
        }
        private List<Announcement> SeedAnnouncement()
        {
            List<Announcement> announcements = new List<Announcement>();

            Announcement announcement;

            announcement = new Announcement()
            {
                Id = 1,
                Title = "Продава се Audi RS7",
                Description = "Мощно Audi RS7 с 720 конски сили, дизелов двигател и много екстри. Перфектно техническо състояние.",
                Price = 89900m,
                Status = "Approved",
                CarId = 1 // Свързано с автомобила Audi RS7 с Id = 1
            };
            announcements.Add(announcement);



            return announcements;
        }
    }
}
