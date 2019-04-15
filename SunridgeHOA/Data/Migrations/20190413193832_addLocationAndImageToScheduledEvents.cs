using Microsoft.EntityFrameworkCore.Migrations;

namespace SunridgeHOA.Data.Migrations
{
    public partial class addLocationAndImageToScheduledEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ScheduledEvents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ScheduledEvents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "ScheduledEvents");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ScheduledEvents");
        }
    }
}
