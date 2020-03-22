using Microsoft.EntityFrameworkCore.Migrations;

namespace WirVsVirus.Database.Migrations
{
    public partial class Mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GeoLatitude",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeoLongitude",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Locations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_LocationId",
                table: "Hospitals",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropColumn(
                name: "GeoLatitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "GeoLongitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Locations");
        }
    }
}
