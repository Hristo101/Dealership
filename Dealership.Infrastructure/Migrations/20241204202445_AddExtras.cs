using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dealership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExtras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtrasForComfort",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityExtras",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "ExtrasForComfort", "SecurityExtras" },
                values: new object[] { new DateTime(2024, 12, 4, 22, 24, 44, 714, DateTimeKind.Local).AddTicks(6020), "Audi RS7 е високопроизводителен спортен седан, оборудван с 4.0-литров V8 битурбо двигател с 600 к.с. (640 к.с. в Performance версията), който ускорява от 0 до 100 км/ч за около 3.5 секунди. Колата разполага с 8-степенна автоматична трансмисия и система за задвижване на четирите колела (quattro), което осигурява отлична стабилност и сцепление. С адаптивно въздушно окачване и високо ефективни спирачки, RS7 предлага както комфорт при дълги пътувания, така и безкомпромисна динамика при спортно шофиране. Интериорът е луксозен, с кожени и спортни седалки, напълно интегрирана мултимедийна система и множество асистиращи технологии за безопасност.", "Климатроник, Кожен салон, Електрически стъкла, Електрически огледала, Електрически седалки, Подгряване на седалки, Стерео уредба, Алуминиеви джанти, Мултифункционален волан, Автопилот, Серво управление, Бордови компютър, Навигационна система", "ABS, ESP, Airbag, Ксенонови фарове, Халогенни фарове, Парктроник, Аларма, Имобилайзер, Централно заключване, Застраховка" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtrasForComfort",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SecurityExtras",
                table: "Sales");

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2024, 12, 4, 22, 5, 53, 62, DateTimeKind.Local).AddTicks(5872), "Мощно Audi RS7 с 720 конски сили, дизелов двигател и много екстри. Перфектно техническо състояние." });
        }
    }
}
