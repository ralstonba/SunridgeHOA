using Microsoft.EntityFrameworkCore.Migrations;

namespace SunridgeHOA.Data.Migrations
{
    public partial class removeRedundantPropsFromAppUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnerHistories_Owners_OwnerID",
                table: "OwnerHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Addresses_AddressID",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Owners_CoOwnerID",
                table: "Owners");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerHistories_Owners_OwnerID",
                table: "OwnerHistories",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Addresses_AddressID",
                table: "Owners",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Owners_CoOwnerID",
                table: "Owners",
                column: "CoOwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnerHistories_Owners_OwnerID",
                table: "OwnerHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Addresses_AddressID",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Owners_CoOwnerID",
                table: "Owners");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerHistories_Owners_OwnerID",
                table: "OwnerHistories",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Addresses_AddressID",
                table: "Owners",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Owners_CoOwnerID",
                table: "Owners",
                column: "CoOwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
