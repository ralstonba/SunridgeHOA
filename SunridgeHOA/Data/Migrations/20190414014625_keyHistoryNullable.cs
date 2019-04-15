using Microsoft.EntityFrameworkCore.Migrations;

namespace SunridgeHOA.Data.Migrations
{
    public partial class keyHistoryNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keys_KeyHistories_KeyHistoryID",
                table: "Keys");

            migrationBuilder.AlterColumn<int>(
                name: "KeyHistoryID",
                table: "Keys",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Keys_KeyHistories_KeyHistoryID",
                table: "Keys",
                column: "KeyHistoryID",
                principalTable: "KeyHistories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keys_KeyHistories_KeyHistoryID",
                table: "Keys");

            migrationBuilder.AlterColumn<int>(
                name: "KeyHistoryID",
                table: "Keys",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Keys_KeyHistories_KeyHistoryID",
                table: "Keys",
                column: "KeyHistoryID",
                principalTable: "KeyHistories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
