using Microsoft.EntityFrameworkCore.Migrations;

namespace WirVsVirus.Database.Migrations
{
    public partial class Mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: true),
                    PostCode = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<int>(nullable: false),
                    Accessability = table.Column<string>(nullable: true),
                    AccessToInternet = table.Column<bool>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "IX_Hotels_LocationId",
                table: "Hotels",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ContactInfoId",
                table: "Locations",
                column: "ContactInfoId",
                unique: true);

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
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "SanitaryInfos");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
