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

            announcement = new Announcement()
            {
                Id = 2,
                Description = "Toyota Tacoma 2018 е сред най-надеждните пикапи на пазара, със здраво шаси и силен двигател 3.5 V6 с мощност от около 278 к.с. и въртящ момент от 359 Нм. Предлага отлична производителност както на асфалт, така и в офроуд условия благодарение на системата 4x4 и наличните TRD Pro версии, които включват специализирано окачване и офроуд гуми.\r\n\r\nТози модел е популярен и заради издръжливостта си – поддържа висока остатъчна стойност на пазара на употребявани автомобили. Toyota Tacoma е идеален избор за активен начин на живот, който комбинира ежедневна употреба с приключения извън града.",
                ExtrasForComfort = "Двузонен автоматичен климатроник, Подгряване на предните седалки, Удобна тапицерия, Електрически регулируеми седалки, Мултимедиен дисплей с тъчскрийн, Аудиосистема JBL, Безключов достъп и стартиране, Слънцезащитни сенници с огледала и осветление, Електрическо задно стъкло, Амбиентно осветление в интериора, Автопилот, Серво управление, Бордови компютър, Навигационна система",
                SecurityExtras = "ABS, ESP, Airbag, Ксенонови фарове, Халогенни фарове, Парктроник, Аларма, Имобилайзер, Централно заключване, Застраховка",
                Price = 92000m,
                Status = "Approved",
                CreatedDate = DateTime.Now,
                CarId = 2
            };
            announcements.Add(announcement);

            announcement = new Announcement()
            {
                Id = 3,
                Description = "Mercedes-Benz S 350 (2018) е луксозен седан, който въплъщава върхови технологии и изтънченост. Той е оборудван с 3.0-литров V6 двигател с мощност от около 286 к.с. и въртящ момент от 600 Нм, което осигурява плавно ускорение и нисък разход на гориво за класа си.\r\n\r\nТази лимузина е символ на комфорт и престиж, като предлага най-нови технологии за автономно шофиране и върхова сигурност. Интериорът е изпълнен с висококачествени материали, а стилът и изпълнението правят S-класата един от лидерите в своя сегмент.",
                ExtrasForComfort = "Мултиконтурни седалки с масаж, Четиризонов климатроник, Ароматизация на купето, Panoramic Sunroof, Ambiente осветление, Мултимедиен дисплей с двойна конфигурация, Електрическа задна врата, Електрически регулиране на волана, Аудиосистема Burmester, Шумоизолиран салон, Автопилот, Серво управление, Бордови компютър, Навигационна система",
                SecurityExtras = "ABS, ESP, Airbag, BAS, Distronic Plus, Active Lane Keeping Assist, Blind Spot Assist, PRE-SAFE, TPMS, Active Brake Assist, 360-градусова камера",
                Price = 195000m,
                Status = "Approved",
                CreatedDate = DateTime.Now,
                CarId = 3
            };
            announcements.Add(announcement);

            return announcements;
        }
    }
}
