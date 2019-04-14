using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SunridgeHOA.Data.Migrations
{
    public partial class AddComplaintFormStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormID",
                table: "Owners",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintForm",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Suggestion = table.Column<string>(nullable: true),
                    StatesID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintForm", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComplaintForm_States_StatesID1",
                        column: x => x.StatesID1,
                        principalTable: "States",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Owners_FormID",
                table: "Owners",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintForm_StatesID1",
                table: "ComplaintForm",
                column: "StatesID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_ComplaintForm_FormID",
                table: "Owners",
                column: "FormID",
                principalTable: "ComplaintForm",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_ComplaintForm_FormID",
                table: "Owners");

            migrationBuilder.DropTable(
                name: "ComplaintForm");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropIndex(
                name: "IX_Owners_FormID",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "FormID",
                table: "Owners");
        }
    }
}
