using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dealership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarImages", "Color", "EngineType", "Horsepower", "Make", "Mileage", "Model", "Speeds", "Year" },
                values: new object[] { 1, "[\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211138.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211219.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211310.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211403.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211429.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211504.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211528.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211604.png\"]", "Сив", "Дизелов", 720, "Audi", 120000, "Rs7", "Автоматик", 2014 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CarId", "Description", "Price", "Status", "Title" },
                values: new object[] { 1, 1, "Мощно Audi RS7 с 720 конски сили, дизелов двигател и много екстри. Перфектно техническо състояние.", 89900m, "Approved", "Продава се Audi RS7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
