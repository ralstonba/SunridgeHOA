using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SunridgeHOA.Data.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HistoryTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SerialNumber = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cost = table.Column<decimal>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    CommonAreaAssetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsPrimary = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    EmergencyContactName = table.Column<string>(nullable: true),
                    EmergencyContactPhone = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    AddressID = table.Column<int>(nullable: false),
                    CoOwnerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Owners_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Owners_Owners_CoOwnerID",
                        column: x => x.CoOwnerID,
                        principalTable: "Owners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CommonAreaAssets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    PurchasePrice = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    CommonAreaAssetID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonAreaAssets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommonAreaAssets_MaintenanceRecords_CommonAreaAssetID",
                        column: x => x.CommonAreaAssetID,
                        principalTable: "MaintenanceRecords",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedListings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ListingDate = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    OwnerID = table.Column<int>(nullable: false),
                    ClassifiedCategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedListings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClassifiedListings_ClassifiedCategories_ClassifiedCategoryID",
                        column: x => x.ClassifiedCategoryID,
                        principalTable: "ClassifiedCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassifiedListings_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeyHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true),
                    DateIssued = table.Column<DateTime>(nullable: false),
                    DateReturned = table.Column<DateTime>(nullable: false),
                    PaidAmount = table.Column<decimal>(nullable: false),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    KeyID = table.Column<int>(nullable: false),
                    OwnerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KeyHistories_Keys_KeyID",
                        column: x => x.KeyID,
                        principalTable: "Keys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeyHistories_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LotNumber = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    InventoryID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false),
                    OwnerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lots_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lots_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerContactTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactValue = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    OwnerID = table.Column<int>(nullable: false),
                    ContactID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerContactTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OwnerContactTypes_ContactTypes_ContactID",
                        column: x => x.ContactID,
                        principalTable: "ContactTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerContactTypes_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    InventoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Lots_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Lots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OwnerHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LotID = table.Column<int>(nullable: false),
                    OwnerID = table.Column<int>(nullable: false),
                    HistoryTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OwnerHistories_HistoryTypes_HistoryTypeID",
                        column: x => x.HistoryTypeID,
                        principalTable: "HistoryTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerHistories_Lots_LotID",
                        column: x => x.LotID,
                        principalTable: "Lots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerHistories_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<float>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DatePaid = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LotID = table.Column<int>(nullable: false),
                    OwnerID = table.Column<int>(nullable: false),
                    TransactionTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transactions_Lots_LotID",
                        column: x => x.LotID,
                        principalTable: "Lots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsMainImage = table.Column<bool>(nullable: false),
                    FileURL = table.Column<string>(nullable: false),
                    ImageContentType = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    OwnerHistoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Files_OwnerHistories_OwnerHistoryID",
                        column: x => x.OwnerHistoryID,
                        principalTable: "OwnerHistories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedListings_ClassifiedCategoryID",
                table: "ClassifiedListings",
                column: "ClassifiedCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedListings_OwnerID",
                table: "ClassifiedListings",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_CommonAreaAssets_CommonAreaAssetID",
                table: "CommonAreaAssets",
                column: "CommonAreaAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_OwnerHistoryID",
                table: "Files",
                column: "OwnerHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_InventoryID",
                table: "InventoryItems",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_KeyHistories_KeyID",
                table: "KeyHistories",
                column: "KeyID");

            migrationBuilder.CreateIndex(
                name: "IX_KeyHistories_OwnerID",
                table: "KeyHistories",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_AddressID",
                table: "Lots",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_OwnerID",
                table: "Lots",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerContactTypes_ContactID",
                table: "OwnerContactTypes",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerContactTypes_OwnerID",
                table: "OwnerContactTypes",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerHistories_HistoryTypeID",
                table: "OwnerHistories",
                column: "HistoryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerHistories_LotID",
                table: "OwnerHistories",
                column: "LotID");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerHistories_OwnerID",
                table: "OwnerHistories",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_AddressID",
                table: "Owners",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_CoOwnerID",
                table: "Owners",
                column: "CoOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_LotID",
                table: "Transactions",
                column: "LotID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OwnerID",
                table: "Transactions",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassifiedListings");

            migrationBuilder.DropTable(
                name: "CommonAreaAssets");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "KeyHistories");

            migrationBuilder.DropTable(
                name: "OwnerContactTypes");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "ClassifiedCategories");

            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "OwnerHistories");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "ContactTypes");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "HistoryTypes");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");
        }
    }
}
