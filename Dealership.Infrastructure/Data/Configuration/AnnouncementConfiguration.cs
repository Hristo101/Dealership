﻿using Dealership.Infrastructure.Data.Models;
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

            announcement = new Announcement()
            {
                Id = 4,
                Description = "Mercedes-Benz E 250 (2017) е елегантен седан, който съчетава иновации и стил. Той е оборудван с 2.0-литров четирицилндров двигател с мощност от около 211 к.с. и въртящ момент от 350 Нм, което осигурява динамично ускорение и оптимален разход на гориво за своя клас.\r\n\r\nТази лимузина е символ на комфорт и стил, като предлага модерни технологии за безопасност и шофиране. Интериорът е изпълнен с първокласни материали, а изящният дизайн прави E-класата едно от водещите превозни средства в своя сегмент.",
               ExtrasForComfort = "Ергономични седалки с многопозиционно регулиране, Триплекс климатроник, Ароматизация на купето, Панорамен покрив, Ambiente осветление, Мултимедиен дисплей с интуитивен интерфейс, Електрическа задна врата, Моторизирано регулиране на волана, Аудиосистема с висока резолюция, Шумоизолирана кабина, Полуавтономна шофьорска система, Серво управление, Бордови компютър, Интегрирана навигация",
               SecurityExtras = "ABS, ESP, Airbag, BAS, Distronic, Активен помощник за лента, Blind Spot Assist, PRE-SAFE, TPMS, Активна спирачна помощ, 360-градусова камера",
                Price = 39900m,
                CreatedDate = DateTime.Now,
                Status = "Approved",
                CarId = 4
            };
            announcements.Add(announcement);

            announcement = new Announcement()
            {
                Id = 5,
                Description = "Volkswagen Passat (2012) е елегантен и практичен седан, който съчетава модерни технологии и комфорт. Оборудван с 2.0-литров TDI двигател с мощност от около 140 к.с. и въртящ момент от 320 Нм, Passat предлага динамично ускорение и отлична горивна ефективност за своя клас. Това е автомобил, който осигурява стабилност на пътя и комфорт за дълги пътувания, като същевременно предлага първокласна безопасност и иновации. Интериорът е практичен, но с внимание към детайла, създавайки приятна и уютна атмосфера.",
                ExtrasForComfort = "Регулируеми седалки с подгряване, Двузонов климатик, Панорамен покрив, Мултимедиен дисплей с интуитивно меню, Електрическа задна врата, Аудиосистема с високо качество, Комфортно управление, Бордови компютър, Навигационна система, Атмосферно осветление, Кожен салон, Вентилирани седалки, Подгряване на волана",
                SecurityExtras = "ABS, ESP, Airbag, BAS, Park Assist, Регулиране на пътната лента, Контрол на стабилността, TPMS, Активна спирачна помощ, Система за предупреждение при сблъсък, 360-градусова камера",
                Price = 8990m,
                Status = "Approved",
                CreatedDate = DateTime.Now,
                CarId = 5
            };
            announcements.Add(announcement);

            announcement = new Announcement()
            {
                Id = 6,
                Description = "BMW X6 (2021) е мощен и стилен кросоувър, който комбинира спортни характеристики с луксозен комфорт. Оборудван с 3.0-литров 6-цилиндров двигател, развиващ около 335 к.с. и въртящ момент от 450 Нм, X6 предлага невероятно ускорение и динамично поведение на пътя. Това е автомобил, който съчетава производителност и елегантност, като същевременно предоставя високо ниво на сигурност и иновации. Интериорът е изпълнен с изключителни материали и модерни технологии, които правят X6 един от лидерите в своя клас.",
                ExtrasForComfort = "Мултиконтурни седалки с масаж, Четиризонов климатроник, Панорамен покрив, Ambient осветление, Мултимедиен дисплей с двоен екран, Аудиосистема Harman Kardon, Електрическа задна врата, Електрическо регулиране на волана, Вентилирани седалки, Шумоизолиран салон, Автопилот, Динамична система за управление на шасито, Бордови компютър, Навигационна система с реални карти",
                SecurityExtras = "ABS, ESP, Airbag, BAS, Adaptive Cruise Control, Active Lane Keeping Assist, Blind Spot Assist, PRE-SAFE, TPMS, Active Brake Assist, 360-градусова камера, Паркинг асистент",
                Price = 103600m,
                Status = "Approved",
                CreatedDate = DateTime.Now,
                CarId = 6
            };
            announcements.Add(announcement);

            announcement = new Announcement()
            {
                Id = 7,
                Description = "Audi A7 (2024) е елегантен и иновативен спортен седан, който съчетава динамични характеристики с луксозен комфорт. Оборудван с 3.0-литров V6 двигател с мощност около 340 к.с. и въртящ момент от 500 Нм, A7 осигурява изключителна производителност и прецизно управление. Автомобилът е идеален за тези, които търсят не само мощност, но и стил, като предлага последни технологии за автономно шофиране и пълна безопасност. Интериорът е луксозен, с висококачествени материали и интуитивни технологии, които правят всяко пътуване незабравимо.",
                ExtrasForComfort = "Мултиконтурни седалки с масаж и подгряване, Четиризонов климатик, Панорамен покрив, Атмосферно осветление, Мултимедиен дисплей с двоен екран и допълнителен контрол, Аудиосистема Bang & Olufsen, Електрическа задна врата, Електрически регулиране на волана, Вентилирани и отопляеми седалки, Шумоизолирана кабина, Автопилот, Интелигентна система за управление на шасито, Бордови компютър, Навигационна система с AR (разширена реалност)",
                SecurityExtras = "ABS, ESP, Airbag, BAS, Adaptive Cruise Control, Active Lane Keeping Assist, Blind Spot Assist, PRE-SAFE, TPMS, Active Brake Assist, 360-градусова камера, Паркинг асистент, Система за предотвратяване на сблъсъци",
                Price = 128840m,
                Status = "Approved",
                CreatedDate = DateTime.Now,
                CarId = 7
            };
            announcements.Add(announcement);
            return announcements;
        }
    }
}
