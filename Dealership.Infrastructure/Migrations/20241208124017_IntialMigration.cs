using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dealership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Horsepower = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EngineType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Speeds = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsInAnnouncement = table.Column<bool>(type: "bit", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarImages = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExtrasForComfort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityExtras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Queries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminResponse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAnswered = table.Column<bool>(type: "bit", nullable: false),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Queries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Queries_Sales_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteAnnouncement",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteAnnouncement", x => new { x.AnnouncementId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserFavoriteAnnouncement_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteAnnouncement_Sales_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarImages", "Color", "EngineType", "Horsepower", "IsInAnnouncement", "Make", "Mileage", "Model", "Speeds", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, "[\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211138.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211219.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211310.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211403.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211429.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211504.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211528.png\",\"~/img/Cars/AudiRs7/Screenshot 2024-12-03 211604.png\"]", "Сив", "Дизелов", 720, false, "Audi", 120000, "Rs7", "Автоматик", null, 2014 },
                    { 2, "[\"~/img/Cars/Toyota/Capture6.PNG\",\"~/img/Cars/Toyota/Capture.PNG\",\"~/img/Cars/Toyota/Capture3.PNG\",\"~/img/Cars/Toyota/Capture4.PNG\",\"~/img/Cars/Toyota/Capture5.PNG\",\"~/img/Cars/Toyota/Capture2.PNG\",\"~/img/Cars/Toyota/Capture7.PNG\",\"~/img/Cars/Toyota/Capture8.PNG\"]", "Жълт", "Бензинов", 278, false, "Toyota", 61000, "Tacoma 3.5 V6", "Автоматик", null, 2018 },
                    { 3, "[\"~/img/Cars/Mercedes/MercedesCapture3.PNG\",\"~/img/Cars/Mercedes/MercedesCapture4.PNG\",\"~/img/Cars/Mercedes/MercedesCapture5.PNG\",\"~/img/Cars/Mercedes/MercedesCapture6.PNG\",\"~/img/Cars/Mercedes/MercedesCapture7.PNG\",\"~/img/Cars/Mercedes/MercedesCapture8.PNG\",\"~/img/Cars/Mercedes/MercedesCapture1.PNG\",\"~/img/Cars/Mercedes/MercedesCapture2.PNG\"]", "Черен", "Дизелов", 286, false, "Mercedes-Benz", 120000, "S 350", "Автоматик", null, 2021 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CarId", "CreatedDate", "Description", "ExtrasForComfort", "Price", "SecurityExtras", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 8, 14, 40, 16, 638, DateTimeKind.Local).AddTicks(6460), "Audi RS7 е високопроизводителен спортен седан, оборудван с 4.0-литров V8 битурбо двигател с 600 к.с. (640 к.с. в Performance версията), който ускорява от 0 до 100 км/ч за около 3.5 секунди. Колата разполага с 8-степенна автоматична трансмисия и система за задвижване на четирите колела (quattro), което осигурява отлична стабилност и сцепление. С адаптивно въздушно окачване и високо ефективни спирачки, RS7 предлага както комфорт при дълги пътувания, така и безкомпромисна динамика при спортно шофиране. Интериорът е луксозен, с кожени и спортни седалки, напълно интегрирана мултимедийна система и множество асистиращи технологии за безопасност.", "Климатроник, Кожен салон, Електрически стъкла, Електрически огледала, Електрически седалки, Подгряване на седалки, Стерео уредба, Алуминиеви джанти, Мултифункционален волан, Автопилот, Серво управление, Бордови компютър, Навигационна система", 89900m, "ABS, ESP, Airbag, Ксенонови фарове, Халогенни фарове, Парктроник, Аларма, Имобилайзер, Централно заключване, Застраховка", "Approved" },
                    { 2, 2, new DateTime(2024, 12, 8, 14, 40, 16, 638, DateTimeKind.Local).AddTicks(6500), "Toyota Tacoma 2018 е сред най-надеждните пикапи на пазара, със здраво шаси и силен двигател 3.5 V6 с мощност от около 278 к.с. и въртящ момент от 359 Нм. Предлага отлична производителност както на асфалт, така и в офроуд условия благодарение на системата 4x4 и наличните TRD Pro версии, които включват специализирано окачване и офроуд гуми.\r\n\r\nТози модел е популярен и заради издръжливостта си – поддържа висока остатъчна стойност на пазара на употребявани автомобили. Toyota Tacoma е идеален избор за активен начин на живот, който комбинира ежедневна употреба с приключения извън града.", "Двузонен автоматичен климатроник, Подгряване на предните седалки, Удобна тапицерия, Електрически регулируеми седалки, Мултимедиен дисплей с тъчскрийн, Аудиосистема JBL, Безключов достъп и стартиране, Слънцезащитни сенници с огледала и осветление, Електрическо задно стъкло, Амбиентно осветление в интериора, Автопилот, Серво управление, Бордови компютър, Навигационна система", 92000m, "ABS, ESP, Airbag, Ксенонови фарове, Халогенни фарове, Парктроник, Аларма, Имобилайзер, Централно заключване, Застраховка", "Approved" },
                    { 3, 3, new DateTime(2024, 12, 8, 14, 40, 16, 638, DateTimeKind.Local).AddTicks(6503), "Mercedes-Benz S 350 (2018) е луксозен седан, който въплъщава върхови технологии и изтънченост. Той е оборудван с 3.0-литров V6 двигател с мощност от около 286 к.с. и въртящ момент от 600 Нм, което осигурява плавно ускорение и нисък разход на гориво за класа си.\r\n\r\nТази лимузина е символ на комфорт и престиж, като предлага най-нови технологии за автономно шофиране и върхова сигурност. Интериорът е изпълнен с висококачествени материали, а стилът и изпълнението правят S-класата един от лидерите в своя сегмент.", "Мултиконтурни седалки с масаж, Четиризонов климатроник, Ароматизация на купето, Panoramic Sunroof, Ambiente осветление, Мултимедиен дисплей с двойна конфигурация, Електрическа задна врата, Електрически регулиране на волана, Аудиосистема Burmester, Шумоизолиран салон, Автопилот, Серво управление, Бордови компютър, Навигационна система", 195000m, "ABS, ESP, Airbag, BAS, Distronic Plus, Active Lane Keeping Assist, Blind Spot Assist, PRE-SAFE, TPMS, Active Brake Assist, 360-градусова камера", "Approved" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_AnnouncementId",
                table: "Queries",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_UserId",
                table: "Queries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CarId",
                table: "Sales",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteAnnouncement_UserId",
                table: "UserFavoriteAnnouncement",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Queries");

            migrationBuilder.DropTable(
                name: "UserFavoriteAnnouncement");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
