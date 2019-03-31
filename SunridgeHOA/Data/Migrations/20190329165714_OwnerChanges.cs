using Microsoft.EntityFrameworkCore.Migrations;

namespace SunridgeHOA.Data.Migrations
{
    public partial class OwnerChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "BoardMembers");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Owners",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OwnerID",
                table: "AspNetUsers",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Owners_OwnerID",
                table: "AspNetUsers",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Owners_OwnerID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OwnerID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "BoardMembers",
                nullable: true);
        }
    }
}
