using System;
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
                    Phone = table.Column<string>(nullable: true),
                    FbUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Object = table.Column<string>(nullable: true),
                    Method = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    InnerException = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.Id);
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
                    BarrierFree = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
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
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
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
                    BedsWithoutVentilatorOtherFLoor = table.Column<int>(nullable: false),
                    HeavyCurrent = table.Column<bool>(nullable: false),
                    HeavyCurentCapacity = table.Column<double>(nullable: false),
                    KitchenCapacity = table.Column<int>(nullable: false),
                    FireProtectionsRegulations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
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
                    BarrierFree = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanitaryInfos", x => x.Id);
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
                    ContactInfoId = table.Column<int>(nullable: false),
                    GymId = table.Column<int>(nullable: true),
                    HotelId = table.Column<int>(nullable: true),
                    HospitalId = table.Column<int>(nullable: true),
                    SanitaryInfoId = table.Column<int>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Locations_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_SanitaryInfos_SanitaryInfoId",
                        column: x => x.SanitaryInfoId,
                        principalTable: "SanitaryInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ContactInfoId",
                table: "Locations",
                column: "ContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_GymId",
                table: "Locations",
                column: "GymId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_HospitalId",
                table: "Locations",
                column: "HospitalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_HotelId",
                table: "Locations",
                column: "HotelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_SanitaryInfoId",
                table: "Locations",
                column: "SanitaryInfoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "SanitaryInfos");
        }
    }
}
