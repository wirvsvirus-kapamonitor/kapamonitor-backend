using Microsoft.EntityFrameworkCore.Migrations;

namespace WirVsVirus.Database.Migrations
{
    public partial class Mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Locations_ContactInfoId",
                table: "Locations");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ContactInfoId",
                table: "Locations",
                column: "ContactInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Locations_ContactInfoId",
                table: "Locations");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ContactInfoId",
                table: "Locations",
                column: "ContactInfoId",
                unique: true);
        }
    }
}
