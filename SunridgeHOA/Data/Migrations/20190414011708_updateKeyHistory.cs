using Microsoft.EntityFrameworkCore.Migrations;

namespace SunridgeHOA.Data.Migrations
{
    public partial class updateKeyHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyHistories_Keys_KeyID",
                table: "KeyHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_KeyHistories_Owners_OwnerID",
                table: "KeyHistories");

            migrationBuilder.DropIndex(
                name: "IX_KeyHistories_KeyID",
                table: "KeyHistories");

            migrationBuilder.DropIndex(
                name: "IX_KeyHistories_OwnerID",
                table: "KeyHistories");

            migrationBuilder.DropColumn(
                name: "KeyID",
                table: "KeyHistories");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "KeyHistories");

            migrationBuilder.AddColumn<int>(
                name: "KeyUnitID",
                table: "Owners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KeyHistoryID",
                table: "Keys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KeyUnitID",
                table: "Keys",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Keys_KeyHistoryID",
                table: "Keys",
                column: "KeyHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_KeyUnitID",
                table: "Keys",
                column: "KeyUnitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Keys_KeyHistories_KeyHistoryID",
                table: "Keys",
                column: "KeyHistoryID",
                principalTable: "KeyHistories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Keys_Owners_KeyUnitID",
                table: "Keys",
                column: "KeyUnitID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keys_KeyHistories_KeyHistoryID",
                table: "Keys");

            migrationBuilder.DropForeignKey(
                name: "FK_Keys_Owners_KeyUnitID",
                table: "Keys");

            migrationBuilder.DropIndex(
                name: "IX_Keys_KeyHistoryID",
                table: "Keys");

            migrationBuilder.DropIndex(
                name: "IX_Keys_KeyUnitID",
                table: "Keys");

            migrationBuilder.DropColumn(
                name: "KeyUnitID",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "KeyHistoryID",
                table: "Keys");

            migrationBuilder.DropColumn(
                name: "KeyUnitID",
                table: "Keys");

            migrationBuilder.AddColumn<int>(
                name: "KeyID",
                table: "KeyHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                table: "KeyHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KeyHistories_KeyID",
                table: "KeyHistories",
                column: "KeyID");

            migrationBuilder.CreateIndex(
                name: "IX_KeyHistories_OwnerID",
                table: "KeyHistories",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_KeyHistories_Keys_KeyID",
                table: "KeyHistories",
                column: "KeyID",
                principalTable: "Keys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KeyHistories_Owners_OwnerID",
                table: "KeyHistories",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
