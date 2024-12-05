using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dealership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreCarsAndAnnouncments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarImages", "Color", "EngineType", "Horsepower", "Make", "Mileage", "Model", "Speeds", "Year" },
                values: new object[,]
                {
                    { 2, "[\"~/img/Cars/Toyota/Capture6.PNG\",\"~/img/Cars/Toyota/Capture.PNG\",\"~/img/Cars/Toyota/Capture3.PNG\",\"~/img/Cars/Toyota/Capture4.PNG\",\"~/img/Cars/Toyota/Capture5.PNG\",\"~/img/Cars/Toyota/Capture2.PNG\",\"~/img/Cars/Toyota/Capture7.PNG\",\"~/img/Cars/Toyota/Capture8.PNG\"]", "Жълт", "Бензинов", 278, "Toyota", 61000, "Tacoma 3.5 V6", "Автоматик", 2018 },
                    { 3, "[\"~/img/Cars/Mercedes/MercedesCapture3.PNG\",\"~/img/Cars/Mercedes/MercedesCapture4.PNG\",\"~/img/Cars/Mercedes/MercedesCapture5.PNG\",\"~/img/Cars/Mercedes/MercedesCapture6.PNG\",\"~/img/Cars/Mercedes/MercedesCapture7.PNG\",\"~/img/Cars/Mercedes/MercedesCapture8.PNG\",\"~/img/Cars/Mercedes/MercedesCapture1.PNG\",\"~/img/Cars/Mercedes/MercedesCapture2.PNG\"]", "Черен", "Дизелов", 286, "Mercedes-Benz", 120000, "S 350", "Автоматик", 2021 }
                });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 5, 9, 4, 17, 448, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CarId", "CreatedDate", "Description", "ExtrasForComfort", "Price", "SecurityExtras", "Status" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2024, 12, 5, 9, 4, 17, 448, DateTimeKind.Local).AddTicks(2399), "Toyota Tacoma 2018 е сред най-надеждните пикапи на пазара, със здраво шаси и силен двигател 3.5 V6 с мощност от около 278 к.с. и въртящ момент от 359 Нм. Предлага отлична производителност както на асфалт, така и в офроуд условия благодарение на системата 4x4 и наличните TRD Pro версии, които включват специализирано окачване и офроуд гуми.\r\n\r\nТози модел е популярен и заради издръжливостта си – поддържа висока остатъчна стойност на пазара на употребявани автомобили. Toyota Tacoma е идеален избор за активен начин на живот, който комбинира ежедневна употреба с приключения извън града.", "Двузонен автоматичен климатроник, Подгряване на предните седалки, Удобна тапицерия, Електрически регулируеми седалки, Мултимедиен дисплей с тъчскрийн, Аудиосистема JBL, Безключов достъп и стартиране, Слънцезащитни сенници с огледала и осветление, Електрическо задно стъкло, Амбиентно осветление в интериора, Автопилот, Серво управление, Бордови компютър, Навигационна система", 92000m, "ABS, ESP, Airbag, Ксенонови фарове, Халогенни фарове, Парктроник, Аларма, Имобилайзер, Централно заключване, Застраховка", "Approved" },
                    { 3, 3, new DateTime(2024, 12, 5, 9, 4, 17, 448, DateTimeKind.Local).AddTicks(2405), "Mercedes-Benz S 350 (2018) е луксозен седан, който въплъщава върхови технологии и изтънченост. Той е оборудван с 3.0-литров V6 двигател с мощност от около 286 к.с. и въртящ момент от 600 Нм, което осигурява плавно ускорение и нисък разход на гориво за класа си.\r\n\r\nТази лимузина е символ на комфорт и престиж, като предлага най-нови технологии за автономно шофиране и върхова сигурност. Интериорът е изпълнен с висококачествени материали, а стилът и изпълнението правят S-класата един от лидерите в своя сегмент.", "Мултиконтурни седалки с масаж, Четиризонов климатроник, Ароматизация на купето, Panoramic Sunroof, Ambiente осветление, Мултимедиен дисплей с двойна конфигурация, Електрическа задна врата, Електрически регулиране на волана, Аудиосистема Burmester, Шумоизолиран салон, Автопилот, Серво управление, Бордови компютър, Навигационна система", 195000m, "ABS, ESP, Airbag, BAS, Distronic Plus, Active Lane Keeping Assist, Blind Spot Assist, PRE-SAFE, TPMS, Active Brake Assist, 360-градусова камера", "Approved" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 22, 24, 44, 714, DateTimeKind.Local).AddTicks(6020));
        }
    }
}
