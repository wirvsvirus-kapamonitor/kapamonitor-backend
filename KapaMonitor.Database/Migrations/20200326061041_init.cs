using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KapaMonitor.Database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    GeoLatitude = table.Column<string>(nullable: true),
                    GeoLongitude = table.Column<string>(nullable: true),
                    Accessability = table.Column<string>(nullable: true),
                    AccessToInternet = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    ContactInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_ContactInfos_ContactInfoId",
                        column: x => x.ContactInfoId,
                        principalTable: "ContactInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Area = table.Column<double>(nullable: false),
                    Beds = table.Column<int>(nullable: false),
                    HeavyCurrent = table.Column<bool>(nullable: false),
                    HeavyCurrentCapacity = table.Column<double>(nullable: false),
                    QuantityWaterConnections = table.Column<int>(nullable: false),
                    BarrierFree = table.Column<bool>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gyms_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IkId = table.Column<string>(nullable: true),
                    IsEmergencyHospital = table.Column<bool>(nullable: false),
                    BedsWithVentilator = table.Column<int>(nullable: false),
                    BedsWithoutVentilator = table.Column<int>(nullable: false),
                    BarrierFree = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitals_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BedsWithVentilatorWithCarpet = table.Column<int>(nullable: false),
                    BedsWithoutVentilatorWithCarpet = table.Column<int>(nullable: false),
                    BedsWithVentilatorOtherFLoor = table.Column<int>(nullable: false),
                    HeavyCurrent = table.Column<bool>(nullable: false),
                    HeavyCurentCapacity = table.Column<double>(nullable: false),
                    KitchenCapacity = table.Column<int>(nullable: false),
                    FireProtectionsRegulations = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanitaryInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuantitySinks = table.Column<int>(nullable: false),
                    QuantityShowers = table.Column<int>(nullable: false),
                    QuantityToilents = table.Column<int>(nullable: false),
                    QuantityBathrooms = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    BarrierFree = table.Column<bool>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanitaryInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanitaryInfos_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_LocationId",
                table: "Gyms",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_LocationId",
                table: "Hospitals",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_LocationId",
                table: "Hotels",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ContactInfoId",
                table: "Locations",
                column: "ContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SanitaryInfos_LocationId",
                table: "SanitaryInfos",
                column: "LocationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "SanitaryInfos");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ContactInfos");
        }
    }
}
