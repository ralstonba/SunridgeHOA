using Microsoft.EntityFrameworkCore.Migrations;

namespace SunridgeHOA.Data.Migrations
{
    public partial class nullableValuesInOwnerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Owners_OwnerID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Addresses_AddressID",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Owners_CoOwnerID",
                table: "Owners");

            migrationBuilder.AlterColumn<int>(
                name: "LotID",
                table: "Owners",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CoOwnerID",
                table: "Owners",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "Owners",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Owners_OwnerID",
                table: "AspNetUsers",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Addresses_AddressID",
                table: "Owners",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Owners_CoOwnerID",
                table: "Owners",
                column: "CoOwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Owners_OwnerID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Addresses_AddressID",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Owners_CoOwnerID",
                table: "Owners");

            migrationBuilder.AlterColumn<int>(
                name: "LotID",
                table: "Owners",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CoOwnerID",
                table: "Owners",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "Owners",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Owners_OwnerID",
                table: "AspNetUsers",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Addresses_AddressID",
                table: "Owners",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Owners_CoOwnerID",
                table: "Owners",
                column: "CoOwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
