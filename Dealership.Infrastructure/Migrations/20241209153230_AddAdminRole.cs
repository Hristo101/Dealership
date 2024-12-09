using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dealership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Model",
                value: "Passat");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CarImages",
                value: "[\"~/img/Cars/BMV/BMVPicture1.png\",\"~/img/Cars/BMV/BMWPicture2.png\",\"~/img/Cars/BMV/BMWPicture3.png\",\"~/img/Cars/BMV/BMVPicture4.png\",\"~/img/Cars/BMV/BMWPicture5.png\",\"~/img/Cars/BMV/BMWPicture6.png\",\"~/img/Cars/BMV/BMVPicture7.png\",\"~/img/Cars/BMV/BMWPicture8.png\"]");

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 9, 17, 32, 29, 998, DateTimeKind.Local).AddTicks(5024));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 9, 17, 32, 29, 998, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 9, 17, 32, 29, 998, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 9, 17, 32, 29, 998, DateTimeKind.Local).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 9, 17, 32, 29, 998, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 9, 17, 32, 29, 998, DateTimeKind.Local).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 9, 17, 32, 29, 998, DateTimeKind.Local).AddTicks(5086));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Model",
                value: "Passat 2.0 TDI");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CarImages",
                value: "[\"~/img/Cars/BMV/BMVPicture1.png\",\"~/img/Cars/BMV/BMVPicture2.png\",\"~/img/Cars/BMV/BMVPicture3.png\",\"~/img/Cars/BMV/BMVPicture4.png\",\"~/img/Cars/BMV/BMVPicture5.png\",\"~/img/Cars/BMV/BMVPicture6.png\",\"~/img/Cars/BMV/BMVPicture7.png\",\"~/img/Cars/BMV/BMVPicture8.png\"]");

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

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 8, 23, 52, 6, 324, DateTimeKind.Local).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 8, 23, 52, 6, 324, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 8, 23, 52, 6, 324, DateTimeKind.Local).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 8, 23, 52, 6, 324, DateTimeKind.Local).AddTicks(4164));
        }
    }
}
