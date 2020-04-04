using Microsoft.EntityFrameworkCore.Migrations;

namespace KapaMonitor.Database.Migrations
{
    public partial class Mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Hospitals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Hospitals",
                type: "text",
                nullable: true);
        }
    }
}
