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
                Description = "Audi RS7 е високопроизводителен спортен седан, оборудван с 4.0-литров V8 битурбо двигател с 600 к.с. (640 к.с. в Performance версията), който ускорява от 0 до 100 км/ч за около 3.5 секунди. Колата разполага с 8-степенна автоматична трансмисия и система за задвижване на четирите колела (quattro), което осигурява отлична стабилност и сцепление. С адаптивно въздушно окачване и високо ефективни спирачки, RS7 предлага както комфорт при дълги пътувания, така и безкомпромисна динамика при спортно шофиране. Интериорът е луксозен, с кожени и спортни седалки, напълно интегрирана мултимедийна система и множество асистиращи технологии за безопасност.",
                ExtrasForComfort = "Климатроник, Кожен салон, Електрически стъкла, Електрически огледала, Електрически седалки, Подгряване на седалки, Стерео уредба, Алуминиеви джанти, Мултифункционален волан, Автопилот, Серво управление, Бордови компютър, Навигационна система",
                SecurityExtras = "ABS, ESP, Airbag, Ксенонови фарове, Халогенни фарове, Парктроник, Аларма, Имобилайзер, Централно заключване, Застраховка",
                Price = 89900m,
                Status = "Approved",
                CreatedDate = DateTime.Now,
                CarId = 1
            };
            announcements.Add(announcement);



            return announcements;
        }
    }
}
