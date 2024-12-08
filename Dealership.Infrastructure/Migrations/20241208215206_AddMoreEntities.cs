using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dealership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarImages", "Color", "EngineType", "Horsepower", "IsInAnnouncement", "Make", "Mileage", "Model", "Speeds", "UserId", "Year" },
                values: new object[,]
                {
                    { 4, "[\"~/img/Cars/MercedesEClass/MercedesEClassPicture1.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture2.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture3.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture4.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture5.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture6.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture7.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture8.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture9.png\",\"~/img/Cars/MercedesEClass/MercedesEClassPicture10.png\"]", "Бял", "Дизелов", 204, false, "Mercedes-Benz", 115000, "E 250", "Автоматик", null, 2017 },
                    { 5, "[\"~/img/Cars/Volkswagen/VKPicture1.png\",\"~/img/Cars/Volkswagen/VKPicture2.png\",\"~/img/Cars/Volkswagen/VKPicture3.png\",\"~/img/Cars/Volkswagen/VKPicture4.png\",\"~/img/Cars/Volkswagen/VKPicture5.png\",\"~/img/Cars/Volkswagen/VKPicture6.png\",\"~/img/Cars/Volkswagen/VKPicture7.png\",\"~/img/Cars/Volkswagen/VKPicture8.png\"]", "Сив", "Дизелов", 140, false, "Volkswagen", 224000, "Passat 2.0 TDI", "Ръчни", null, 2012 },
                    { 6, "[\"~/img/Cars/BMV/BMVPicture1.png\",\"~/img/Cars/BMV/BMVPicture2.png\",\"~/img/Cars/BMV/BMVPicture3.png\",\"~/img/Cars/BMV/BMVPicture4.png\",\"~/img/Cars/BMV/BMVPicture5.png\",\"~/img/Cars/BMV/BMVPicture6.png\",\"~/img/Cars/BMV/BMVPicture7.png\",\"~/img/Cars/BMV/BMVPicture8.png\"]", "Черен", "Дизелов", 286, false, "BMW", 129000, "X6 3.0d", "Автоматик", null, 2021 },
                    { 7, "[\"~/img/Cars/AudiA7/AudiA7Picture1.png\",\"~/img/Cars/AudiA7/AudiA7Picture2.png\",\"~/img/Cars/AudiA7/AudiA7Picture3.png\",\"~/img/Cars/AudiA7/AudiA7Picture4.png\",\"~/img/Cars/AudiA7/AudiA7Picture5.png\"]", "Черен", "Дизелов", 286, false, "Audi", 5000, "A7 50 TDI", "Автоматик", null, 2024 }
                });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 8, 23, 52, 6, 324, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 8, 23, 52, 6, 324, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 8, 23, 52, 6, 324, DateTimeKind.Local).AddTicks(4153));

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CarId", "CreatedDate", "Description", "ExtrasForComfort", "Price", "SecurityExtras", "Status" },
                values: new object[,]
                {
                    { 4, 4, new DateTime(2024, 12, 8, 23, 52, 6, 324, DateTimeKind.Local).AddTicks(4156), "Mercedes-Benz E 250 (2017) е елегантен седан, който съчетава иновации и стил. Той е оборудван с 2.0-литров четирицилндров двигател с мощност от около 211 к.с. и въртящ момент от 350 Нм, което осигурява динамично ускорение и оптимален разход на гориво за своя клас.\r\n\r\nТази лимузина е символ на комфорт и стил, като предлага модерни технологии за безопасност и шофиране. Интериорът е изпълнен с първокласни материали, а изящният дизайн прави E-класата едно от водещите превозни средства в своя сегмент.", "Ергономични седалки с многопозиционно регулиране, Триплекс климатроник, Ароматизация на купето, Панорамен покрив, Ambiente осветление, Мултимедиен дисплей с интуитивен интерфейс, Електрическа задна врата, Моторизирано регулиране на волана, Аудиосистема с висока резолюция, Шумоизолирана кабина, Полуавтономна шофьорска система, Серво управление, Бордови компютър, Интегрирана навигация", 39900m, "ABS, ESP, Airbag, BAS, Distronic, Активен помощник за лента, Blind Spot Assist, PRE-SAFE, TPMS, Активна спирачна помощ, 360-градусова камера", "Approved" },
                    { 5, 5, new DateTime(2024, 12, 8, 23, 52, 6, 324, DateTimeKind.Local).AddTicks(4158), "Volkswagen Passat (2012) е елегантен и практичен седан, който съчетава модерни технологии и комфорт. Оборудван с 2.0-литров TDI двигател с мощност от около 140 к.с. и въртящ момент от 320 Нм, Passat предлага динамично ускорение и отлична горивна ефективност за своя клас. Това е автомобил, който осигурява стабилност на пътя и комфорт за дълги пътувания, като същевременно предлага първокласна безопасност и иновации. Интериорът е практичен, но с внимание към детайла, създавайки приятна и уютна атмосфера.", "Регулируеми седалки с подгряване, Двузонов климатик, Панорамен покрив, Мултимедиен дисплей с интуитивно меню, Електрическа задна врата, Аудиосистема с високо качество, Комфортно управление, Бордови компютър, Навигационна система, Атмосферно осветление, Кожен салон, Вентилирани седалки, Подгряване на волана", 8990m, "ABS, ESP, Airbag, BAS, Park Assist, Регулиране на пътната лента, Контрол на стабилността, TPMS, Активна спирачна помощ, Система за предупреждение при сблъсък, 360-градусова камера", "Approved" },
                    { 6, 6, new DateTime(2024, 12, 8, 23, 52, 6, 324, DateTimeKind.Local).AddTicks(4162), "BMW X6 (2021) е мощен и стилен кросоувър, който комбинира спортни характеристики с луксозен комфорт. Оборудван с 3.0-литров 6-цилиндров двигател, развиващ около 335 к.с. и въртящ момент от 450 Нм, X6 предлага невероятно ускорение и динамично поведение на пътя. Това е автомобил, който съчетава производителност и елегантност, като същевременно предоставя високо ниво на сигурност и иновации. Интериорът е изпълнен с изключителни материали и модерни технологии, които правят X6 един от лидерите в своя клас.", "Мултиконтурни седалки с масаж, Четиризонов климатроник, Панорамен покрив, Ambient осветление, Мултимедиен дисплей с двоен екран, Аудиосистема Harman Kardon, Електрическа задна врата, Електрическо регулиране на волана, Вентилирани седалки, Шумоизолиран салон, Автопилот, Динамична система за управление на шасито, Бордови компютър, Навигационна система с реални карти", 103600m, "ABS, ESP, Airbag, BAS, Adaptive Cruise Control, Active Lane Keeping Assist, Blind Spot Assist, PRE-SAFE, TPMS, Active Brake Assist, 360-градусова камера, Паркинг асистент", "Approved" },
                    { 7, 7, new DateTime(2024, 12, 8, 23, 52, 6, 324, DateTimeKind.Local).AddTicks(4164), "Audi A7 (2024) е елегантен и иновативен спортен седан, който съчетава динамични характеристики с луксозен комфорт. Оборудван с 3.0-литров V6 двигател с мощност около 340 к.с. и въртящ момент от 500 Нм, A7 осигурява изключителна производителност и прецизно управление. Автомобилът е идеален за тези, които търсят не само мощност, но и стил, като предлага последни технологии за автономно шофиране и пълна безопасност. Интериорът е луксозен, с висококачествени материали и интуитивни технологии, които правят всяко пътуване незабравимо.", "Мултиконтурни седалки с масаж и подгряване, Четиризонов климатик, Панорамен покрив, Атмосферно осветление, Мултимедиен дисплей с двоен екран и допълнителен контрол, Аудиосистема Bang & Olufsen, Електрическа задна врата, Електрически регулиране на волана, Вентилирани и отопляеми седалки, Шумоизолирана кабина, Автопилот, Интелигентна система за управление на шасито, Бордови компютър, Навигационна система с AR (разширена реалност)", 128840m, "ABS, ESP, Airbag, BAS, Adaptive Cruise Control, Active Lane Keeping Assist, Blind Spot Assist, PRE-SAFE, TPMS, Active Brake Assist, 360-градусова камера, Паркинг асистент, Система за предотвратяване на сблъсъци", "Approved" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 8, 14, 40, 16, 638, DateTimeKind.Local).AddTicks(6460));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 8, 14, 40, 16, 638, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 8, 14, 40, 16, 638, DateTimeKind.Local).AddTicks(6503));
        }
    }
}
