using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SunridgeHOA.Data.Migrations
{
    public partial class BoardMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lots_OwnerID",
                table: "Lots");

            migrationBuilder.AddColumn<bool>(
                name: "IsBoardMember",
                table: "Owners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LotID",
                table: "Owners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Owners",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoardMembers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Position = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    OwnerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardMembers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BoardMembers_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lots_OwnerID",
                table: "Lots",
                column: "OwnerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardMembers_OwnerID",
                table: "BoardMembers",
                column: "OwnerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardMembers");

            migrationBuilder.DropIndex(
                name: "IX_Lots_OwnerID",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "IsBoardMember",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "LotID",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Owners");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_OwnerID",
                table: "Lots",
                column: "OwnerID");
        }
    }
}
