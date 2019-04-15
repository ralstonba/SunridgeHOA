using Microsoft.EntityFrameworkCore.Migrations;

namespace SunridgeHOA.Data.Migrations
{
    public partial class letOwnersOwnMultipleLots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Owners_OwnerID",
                table: "Lots");

            migrationBuilder.DropIndex(
                name: "IX_Lots_OwnerID",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Lots");

            migrationBuilder.AddColumn<int>(
                name: "LotsID",
                table: "Owners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LotsID",
                table: "Lots",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_LotID",
                table: "Owners",
                column: "LotID");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_LotsID",
                table: "Lots",
                column: "LotsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Owners_LotsID",
                table: "Lots",
                column: "LotsID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Lots_LotID",
                table: "Owners",
                column: "LotID",
                principalTable: "Lots",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Owners_LotsID",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Lots_LotID",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_LotID",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Lots_LotsID",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "LotsID",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "LotsID",
                table: "Lots");

            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                table: "Lots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lots_OwnerID",
                table: "Lots",
                column: "OwnerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Owners_OwnerID",
                table: "Lots",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
