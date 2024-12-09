﻿// <auto-generated />
using System;
using Dealership.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dealership.Infrastructure.Migrations
{
    [DbContext(typeof(CarDealershipContext))]
    [Migration("20241209155812_CreatRoleAdmin")]
    partial class CreatRoleAdmin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtrasForComfort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SecurityExtras")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 1,
                            CreatedDate = new DateTime(2024, 12, 9, 17, 58, 11, 746, DateTimeKind.Local).AddTicks(8548),
                            Description = "Audi RS7 е високопроизводителен спортен седан, оборудван с 4.0-литров V8 битурбо двигател с 600 к.с. (640 к.с. в Performance версията), който ускорява от 0 до 100 км/ч за около 3.5 секунди. Колата разполага с 8-степенна автоматична трансмисия и система за задвижване на четирите колела (quattro), което осигурява отлична стабилност и сцепление. С адаптивно въздушно окачване и високо ефективни спирачки, RS7 предлага както комфорт при дълги пътувания, така и безкомпромисна динамика при спортно шофиране. Интериорът е луксозен, с кожени и спортни седалки, напълно интегрирана мултимедийна система и множество асистиращи технологии за безопасност.",
                            ExtrasForComfort = "Климатроник, Кожен салон, Електрически стъкла, Електрически огледала, Електрически седалки, Подгряване на седалки, Стерео уредба, Алуминиеви джанти, Мултифункционален волан, Автопилот, Серво управление, Бордови компютър, Навигационна система",
                            Price = 89900m,
                            SecurityExtras = "ABS, ESP, Airbag, Ксенонови фарове, Халогенни фарове, Парктроник, Аларма, Имобилайзер, Централно заключване, Застраховка",
                            Status = "Approved"
                        },
                        new
                        {
                            Id = 2,
                            CarId = 2,
                            CreatedDate = new DateTime(2024, 12, 9, 17, 58, 11, 746, DateTimeKind.Local).AddTicks(8590),
                            Description = "Toyota Tacoma 2018 е сред най-надеждните пикапи на пазара, със здраво шаси и силен двигател 3.5 V6 с мощност от около 278 к.с. и въртящ момент от 359 Нм. Предлага отлична производителност както на асфалт, така и в офроуд условия благодарение на системата 4x4 и наличните TRD Pro версии, които включват специализирано окачване и офроуд гуми.\r\n\r\nТози модел е популярен и заради издръжливостта си – поддържа висока остатъчна стойност на пазара на употребявани автомобили. Toyota Tacoma е идеален избор за активен начин на живот, който комбинира ежедневна употреба с приключения извън града.",
                            ExtrasForComfort = "Двузонен автоматичен климатроник, Подгряване на предните седалки, Удобна тапицерия, Електрически регулируеми седалки, Мултимедиен дисплей с тъчскрийн, Аудиосистема JBL, Безключов достъп и стартиране, Слънцезащитни сенници с огледала и осветление, Електрическо задно стъкло, Амбиентно осветление в интериора, Автопилот, Серво управление, Бордови компютър, Навигационна система",
                            Price = 92000m,
                            SecurityExtras = "ABS, ESP, Airbag, Ксенонови фарове, Халогенни фарове, Парктроник, Аларма, Имобилайзер, Централно заключване, Застраховка",
                            Status = "Approved"
                        },
                        new
                        {
                            Id = 3,
                            CarId = 3,
                            CreatedDate = new DateTime(2024, 12, 9, 17, 58, 11, 746, DateTimeKind.Local).AddTicks(8595),
                            Description = "Mercedes-Benz S 350 (2018) е луксозен седан, който въплъщава върхови технологии и изтънченост. Той е оборудван с 3.0-литров V6 двигател с мощност от около 286 к.с. и въртящ момент от 600 Нм, което осигурява плавно ускорение и нисък разход на гориво за класа си.\r\n\r\nТази лимузина е символ на комфорт и престиж, като предлага най-нови технологии за автономно шофиране и върхова сигурност. Интериорът е изпълнен с висококачествени материали, а стилът и изпълнението правят S-класата един от лидерите в своя сегмент.",
                            ExtrasForComfort = "Мултиконтурни седалки с масаж, Четиризонов климатроник, Ароматизация на купето, Panoramic Sunroof, Ambiente осветление, Мултимедиен дисплей с двойна конфигурация, Електрическа задна врата, Електрически регулиране на волана, Аудиосистема Burmester, Шумоизолиран салон, Автопилот, Серво управление, Бордови компютър, Навигационна система",
                            Price = 195000m,
                            SecurityExtras = "ABS, ESP, Airbag, BAS, Distronic Plus, Active Lane Keeping Assist, Blind Spot Assist, PRE-SAFE, TPMS, Active Brake Assist, 360-градусова камера",
                            Status = "Approved"
                        },
                        new
                        {
                            Id = 4,
                            CarId = 4,
                            CreatedDate = new DateTime(2024, 12, 9, 17, 58, 11, 746, DateTimeKind.Local).AddTicks(8599),
                            Description = "Mercedes-Benz E 250 (2017) е елегантен седан, който съчетава иновации и стил. Той е оборудван с 2.0-литров четирицилндров двигател с мощност от около 211 к.с. и въртящ момент от 350 Нм, което осигурява динамично ускорение и оптимален разход на гориво за своя клас.\r\n\r\nТази лимузина е символ на комфорт и стил, като предлага модерни технологии за безопасност и шофиране. Интериорът е изпълнен с първокласни материали, а изящният дизайн прави E-класата едно от водещите превозни средства в своя сегмент.",
                            ExtrasForComfort = "Ергономични седалки с многопозиционно регулиране, Триплекс климатроник, Ароматизация на купето, Панорамен покрив, Ambiente осветление, Мултимедиен дисплей с интуитивен интерфейс, Електрическа задна врата, Моторизирано регулиране на волана, Аудиосистема с висока резолюция, Шумоизолирана кабина, Полуавтономна шофьорска система, Серво управление, Бордови компютър, Интегрирана навигация",
                            Price = 39900m,
                            SecurityExtras = "ABS, ESP, Airbag, BAS, Distronic, Активен помощник за лента, Blind Spot Assist, PRE-SAFE, TPMS, Активна спирачна помощ, 360-градусова камера",
                            Status = "Approved"
                        },
                        new
                        {
                            Id = 5,
                            CarId = 5,
                            CreatedDate = new DateTime(2024, 12, 9, 17, 58, 11, 746, DateTimeKind.Local).AddTicks(8602),
                            Description = "Volkswagen Passat (2012) е елегантен и практичен седан, който съчетава модерни технологии и комфорт. Оборудван с 2.0-литров TDI двигател с мощност от около 140 к.с. и въртящ момент от 320 Нм, Passat предлага динамично ускорение и отлична горивна ефективност за своя клас. Това е автомобил, който осигурява стабилност на пътя и комфорт за дълги пътувания, като същевременно предлага първокласна безопасност и иновации. Интериорът е практичен, но с внимание към детайла, създавайки приятна и уютна атмосфера.",
                            ExtrasForComfort = "Регулируеми седалки с подгряване, Двузонов климатик, Панорамен покрив, Мултимедиен дисплей с интуитивно меню, Електрическа задна врата, Аудиосистема с високо качество, Комфортно управление, Бордови компютър, Навигационна система, Атмосферно осветление, Кожен салон, Вентилирани седалки, Подгряване на волана",
                            Price = 8990m,
                            SecurityExtras = "ABS, ESP, Airbag, BAS, Park Assist, Регулиране на пътната лента, Контрол на стабилността, TPMS, Активна спирачна помощ, Система за предупреждение при сблъсък, 360-градусова камера",
                            Status = "Approved"
                        },
                        new
                        {
                            Id = 6,
                            CarId = 6,
                            CreatedDate = new DateTime(2024, 12, 9, 17, 58, 11, 746, DateTimeKind.Local).AddTicks(8607),
                            Description = "BMW X6 (2021) е мощен и стилен кросоувър, който комбинира спортни характеристики с луксозен комфорт. Оборудван с 3.0-литров 6-цилиндров двигател, развиващ около 335 к.с. и въртящ момент от 450 Нм, X6 предлага невероятно ускорение и динамично поведение на пътя. Това е автомобил, който съчетава производителност и елегантност, като същевременно предоставя високо ниво на сигурност и иновации. Интериорът е изпълнен с изключителни материали и модерни технологии, които правят X6 един от лидерите в своя клас.",
                            ExtrasForComfort = "Мултиконтурни седалки с масаж, Четиризонов климатроник, Панорамен покрив, Ambient осветление, Мултимедиен дисплей с двоен екран, Аудиосистема Harman Kardon, Електрическа задна врата, Електрическо регулиране на волана, Вентилирани седалки, Шумоизолиран салон, Автопилот, Динамична система за управление на шасито, Бордови компютър, Навигационна система с реални карти",
                            Price = 103600m,
                            SecurityExtras = "ABS, ESP, Airbag, BAS, Adaptive Cruise Control, Active Lane Keeping Assist, Blind Spot Assist, PRE-SAFE, TPMS, Active Brake Assist, 360-градусова камера, Паркинг асистент",
                            Status = "Approved"
                        },
                        new
                        {
                            Id = 7,
                            CarId = 7,
                            CreatedDate = new DateTime(2024, 12, 9, 17, 58, 11, 746, DateTimeKind.Local).AddTicks(8610),
                            Description = "Audi A7 (2024) е елегантен и иновативен спортен седан, който съчетава динамични характеристики с луксозен комфорт. Оборудван с 3.0-литров V6 двигател с мощност около 340 к.с. и въртящ момент от 500 Нм, A7 осигурява изключителна производителност и прецизно управление. Автомобилът е идеален за тези, които търсят не само мощност, но и стил, като предлага последни технологии за автономно шофиране и пълна безопасност. Интериорът е луксозен, с висококачествени материали и интуитивни технологии, които правят всяко пътуване незабравимо.",
                            ExtrasForComfort = "Мултиконтурни седалки с масаж и подгряване, Четиризонов климатик, Панорамен покрив, Атмосферно осветление, Мултимедиен дисплей с двоен екран и допълнителен контрол, Аудиосистема Bang & Olufsen, Електрическа задна врата, Електрически регулиране на волана, Вентилирани и отопляеми седалки, Шумоизолирана кабина, Автопилот, Интелигентна система за управление на шасито, Бордови компютър, Навигационна система с AR (разширена реалност)",
                            Price = 128840m,
                            SecurityExtras = "ABS, ESP, Airbag, BAS, Adaptive Cruise Control, Active Lane Keeping Assist, Blind Spot Assist, PRE-SAFE, TPMS, Active Brake Assist, 360-градусова камера, Паркинг асистент, Система за предотвратяване на сблъсъци",
                            Status = "Approved"
                        });
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CarImages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EngineType")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Horsepower")
                        .HasColumnType("int");

                    b.Property<bool>("IsInAnnouncement")
                        .HasColumnType("bit");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Speeds")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarImages = "[\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211138.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211219.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211310.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211403.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211429.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211504.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211528.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211604.png\"]",
                            Color = "Сив",
                            EngineType = "Дизелов",
                            Horsepower = 720,
                            IsInAnnouncement = false,
                            Make = "Audi",
                            Mileage = 120000,
                            Model = "Rs7",
                            Speeds = "Автоматик",
                            Year = 2014
                        },
                        new
                        {
                            Id = 2,
                            CarImages = "[\"~/img/Cars/Toyota/Capture6.PNG\",\"~/img/Cars/Toyota/Capture.PNG\",\"~/img/Cars/Toyota/Capture3.PNG\",\"~/img/Cars/Toyota/Capture4.PNG\",\"~/img/Cars/Toyota/Capture5.PNG\",\"~/img/Cars/Toyota/Capture2.PNG\",\"~/img/Cars/Toyota/Capture7.PNG\",\"~/img/Cars/Toyota/Capture8.PNG\"]",
                            Color = "Жълт",
                            EngineType = "Бензинов",
                            Horsepower = 278,
                            IsInAnnouncement = false,
                            Make = "Toyota",
                            Mileage = 61000,
                            Model = "Tacoma 3.5 V6",
                            Speeds = "Автоматик",
                            Year = 2018
                        },
                        new
                        {
                            Id = 3,
                            CarImages = "[\"~/img/Cars/Mercedes/MercedesCapture3.PNG\",\"~/img/Cars/Mercedes/MercedesCapture4.PNG\",\"~/img/Cars/Mercedes/MercedesCapture5.PNG\",\"~/img/Cars/Mercedes/MercedesCapture6.PNG\",\"~/img/Cars/Mercedes/MercedesCapture7.PNG\",\"~/img/Cars/Mercedes/MercedesCapture8.PNG\",\"~/img/Cars/Mercedes/MercedesCapture1.PNG\",\"~/img/Cars/Mercedes/MercedesCapture2.PNG\"]",
                            Color = "Черен",
                            EngineType = "Дизелов",
                            Horsepower = 286,
                            IsInAnnouncement = false,
                            Make = "Mercedes-Benz",
                            Mileage = 120000,
                            Model = "S 350",
                            Speeds = "Автоматик",
                            Year = 2021
                        },
                        new
                        {
                            Id = 4,
                            CarImages = "[\"~/img/Cars/MercedesEClass/MercedesEClassPicture1.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture2.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture3.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture4.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture5.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture6.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture7.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture8.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture9.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture10.png\"]",
                            Color = "Бял",
                            EngineType = "Дизелов",
                            Horsepower = 204,
                            IsInAnnouncement = false,
                            Make = "Mercedes-Benz",
                            Mileage = 115000,
                            Model = "E 250",
                            Speeds = "Автоматик",
                            Year = 2017
                        },
                        new
                        {
                            Id = 5,
                            CarImages = "[\"~/img/Cars/Volkswagen/VKPicture1.png\",\"~/img/Cars/Volkswagen/VKPicture2.png\",\"~/img/Cars/Volkswagen/VKPicture3.png\",\"~/img/Cars/Volkswagen/VKPicture4.png\",\"~/img/Cars/Volkswagen/VKPicture5.png\",\"~/img/Cars/Volkswagen/VKPicture6.png\",\"~/img/Cars/Volkswagen/VKPicture7.png\",\"~/img/Cars/Volkswagen/VKPicture8.png\"]",
                            Color = "Сив",
                            EngineType = "Дизелов",
                            Horsepower = 140,
                            IsInAnnouncement = false,
                            Make = "Volkswagen",
                            Mileage = 224000,
                            Model = "Passat",
                            Speeds = "Ръчни",
                            Year = 2012
                        },
                        new
                        {
                            Id = 6,
                            CarImages = "[\"~/img/Cars/BMV/BMVPicture1.png\",\"~/img/Cars/BMV/BMWPicture2.png\",\"~/img/Cars/BMV/BMWPicture3.png\",\"~/img/Cars/BMV/BMVPicture4.png\",\"~/img/Cars/BMV/BMWPicture5.png\",\"~/img/Cars/BMV/BMWPicture6.png\",\"~/img/Cars/BMV/BMVPicture7.png\",\"~/img/Cars/BMV/BMWPicture8.png\"]",
                            Color = "Черен",
                            EngineType = "Дизелов",
                            Horsepower = 286,
                            IsInAnnouncement = false,
                            Make = "BMW",
                            Mileage = 129000,
                            Model = "X6 3.0d",
                            Speeds = "Автоматик",
                            Year = 2021
                        },
                        new
                        {
                            Id = 7,
                            CarImages = "[\"~/img/Cars/AudiA7/AudiA7Picture1.png\",\"~/img/Cars/AudiA7/AudiA7Picture2.png\",\"~/img/Cars/AudiA7/AudiA7Picture3.png\",\"~/img/Cars/AudiA7/AudiA7Picture4.png\",\"~/img/Cars/AudiA7/AudiA7Picture5.png\"]",
                            Color = "Черен",
                            EngineType = "Дизелов",
                            Horsepower = 286,
                            IsInAnnouncement = false,
                            Make = "Audi",
                            Mileage = 5000,
                            Model = "A7 50 TDI",
                            Speeds = "Автоматик",
                            Year = 2024
                        });
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.Query", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdminResponse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AnnouncementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAnswered")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AnnouncementId");

                    b.HasIndex("UserId");

                    b.ToTable("Queries");
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.UserFavoriteAnnouncement", b =>
                {
                    b.Property<int>("AnnouncementId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("AnnouncementId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFavoriteAnnouncement");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.Announcement", b =>
                {
                    b.HasOne("Dealership.Infrastructure.Data.Models.Car", "Car")
                        .WithMany("Announcements")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.Car", b =>
                {
                    b.HasOne("Dealership.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.Comment", b =>
                {
                    b.HasOne("Dealership.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.Query", b =>
                {
                    b.HasOne("Dealership.Infrastructure.Data.Models.Announcement", "Announcement")
                        .WithMany("Queries")
                        .HasForeignKey("AnnouncementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dealership.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("Queries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Announcement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.UserFavoriteAnnouncement", b =>
                {
                    b.HasOne("Dealership.Infrastructure.Data.Models.Announcement", "Announcement")
                        .WithMany("FavoriteUsers")
                        .HasForeignKey("AnnouncementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dealership.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("FavoriteAnnouncements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Announcement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Dealership.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Dealership.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dealership.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Dealership.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.Announcement", b =>
                {
                    b.Navigation("FavoriteUsers");

                    b.Navigation("Queries");
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Comments");

                    b.Navigation("FavoriteAnnouncements");

                    b.Navigation("Queries");
                });

            modelBuilder.Entity("Dealership.Infrastructure.Data.Models.Car", b =>
                {
                    b.Navigation("Announcements");
                });
#pragma warning restore 612, 618
        }
    }
}
