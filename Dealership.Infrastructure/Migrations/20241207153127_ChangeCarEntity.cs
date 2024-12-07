using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dealership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCarEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 7, 17, 31, 27, 207, DateTimeKind.Local).AddTicks(4793));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 7, 17, 31, 27, 207, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 7, 17, 31, 27, 207, DateTimeKind.Local).AddTicks(4853));

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_UserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_UserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 6, 20, 55, 13, 350, DateTimeKind.Local).AddTicks(102));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 6, 20, 55, 13, 350, DateTimeKind.Local).AddTicks(143));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 6, 20, 55, 13, 350, DateTimeKind.Local).AddTicks(146));
        }
    }
}
