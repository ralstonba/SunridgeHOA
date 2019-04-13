﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SunridgeHOA.Data;

namespace SunridgeHOA.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SunridgeHOA.Models.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("Zip");

                    b.HasKey("ID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SunridgeHOA.Models.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<string>("Header");

                    b.Property<string>("Image");

                    b.HasKey("Id");

                    b.ToTable("Banner");
                });

            modelBuilder.Entity("SunridgeHOA.Models.BoardMember", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OwnerID");

                    b.Property<string>("Position");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.ToTable("BoardMembers");
                });

            modelBuilder.Entity("SunridgeHOA.Models.ClassifiedCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("ClassifiedCategories");
                });

            modelBuilder.Entity("SunridgeHOA.Models.ClassifiedListing", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassifiedCategoryID");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Image");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<DateTime>("ListingDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OwnerID");

                    b.Property<string>("PhoneNumber");

                    b.Property<decimal>("Price");

                    b.HasKey("ID");

                    b.HasIndex("ClassifiedCategoryID");

                    b.HasIndex("OwnerID");

                    b.ToTable("ClassifiedListings");
                });

            modelBuilder.Entity("SunridgeHOA.Models.CommonAreaAsset", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommonAreaAssetID");

                    b.Property<string>("Description");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("PurchaseDate");

                    b.Property<decimal>("PurchasePrice");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("CommonAreaAssetID");

                    b.ToTable("CommonAreaAssets");
                });

            modelBuilder.Entity("SunridgeHOA.Models.ContactType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.ToTable("ContactTypes");
                });

            modelBuilder.Entity("SunridgeHOA.Models.File", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("FileType")
                        .IsRequired();

                    b.Property<string>("FileURL")
                        .IsRequired();

                    b.Property<string>("ImageContentType");

                    b.Property<bool>("IsArchive");

                    b.Property<bool>("IsMainImage");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<int>("OwnerHistoryID");

                    b.HasKey("ID");

                    b.HasIndex("OwnerHistoryID");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("SunridgeHOA.Models.HistoryType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("HistoryTypes");
                });

            modelBuilder.Entity("SunridgeHOA.Models.InventoryItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("InventoryID");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("InventoryID");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("SunridgeHOA.Models.Key", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsArchive");

                    b.Property<int?>("KeyHistoryID");

                    b.Property<int?>("KeyUnitID");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("SerialNumber");

                    b.HasKey("ID");

                    b.HasIndex("KeyHistoryID");

                    b.HasIndex("KeyUnitID");

                    b.ToTable("Keys");
                });

            modelBuilder.Entity("SunridgeHOA.Models.KeyHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateIssued");

                    b.Property<DateTime>("DateReturned");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<decimal>("PaidAmount");

                    b.Property<string>("Status");

                    b.HasKey("ID");

                    b.ToTable("KeyHistories");
                });

            modelBuilder.Entity("SunridgeHOA.Models.Lot", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressID");

                    b.Property<int>("InventoryID");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("LotNumber");

                    b.Property<int?>("LotsID");

                    b.Property<string>("Status");

                    b.Property<string>("TaxID");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.HasIndex("LotsID");

                    b.ToTable("Lots");
                });

            modelBuilder.Entity("SunridgeHOA.Models.MaintenanceRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommonAreaAssetID");

                    b.Property<decimal>("Cost");

                    b.Property<DateTime?>("DateCompleted");

                    b.Property<string>("Description");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.HasKey("ID");

                    b.ToTable("MaintenanceRecords");
                });

            modelBuilder.Entity("SunridgeHOA.Models.Owner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressID");

                    b.Property<DateTime>("Birthday");

                    b.Property<int?>("CoOwnerID");

                    b.Property<string>("EmergencyContactName");

                    b.Property<string>("EmergencyContactPhone");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<bool?>("IsArchive");

                    b.Property<bool>("IsBoardMember");

                    b.Property<bool>("IsPrimary");

                    b.Property<int?>("KeyUnitID");

                    b.Property<DateTime?>("LastModifiedDate");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int?>("LotID");

                    b.Property<int>("LotsID");

                    b.Property<string>("Occupation");

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.HasIndex("CoOwnerID");

                    b.HasIndex("LotID");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("SunridgeHOA.Models.OwnerContactType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactID");

                    b.Property<string>("ContactValue");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<int>("OwnerID");

                    b.HasKey("ID");

                    b.HasIndex("ContactID");

                    b.HasIndex("OwnerID");

                    b.ToTable("OwnerContactTypes");
                });

            modelBuilder.Entity("SunridgeHOA.Models.OwnerHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("HistoryTypeID");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<int>("LotID");

                    b.Property<int>("OwnerID");

                    b.HasKey("ID");

                    b.HasIndex("HistoryTypeID");

                    b.HasIndex("LotID");

                    b.HasIndex("OwnerID");

                    b.ToTable("OwnerHistories");
                });

            modelBuilder.Entity("SunridgeHOA.Models.ScheduledEvent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime?>("End");

                    b.Property<string>("Image");

                    b.Property<bool>("IsFullDay");

                    b.Property<string>("Location");

                    b.Property<DateTime>("Start");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("ScheduledEvents");
                });

            modelBuilder.Entity("SunridgeHOA.Models.Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FilePath")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("SunridgeHOA.Models.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DatePaid");

                    b.Property<string>("Description");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<int>("LotID");

                    b.Property<int>("OwnerID");

                    b.Property<string>("Status");

                    b.Property<int>("TransactionTypeId");

                    b.HasKey("ID");

                    b.HasIndex("LotID");

                    b.HasIndex("OwnerID");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SunridgeHOA.Models.TransactionType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.HasKey("ID");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("SunridgeHOA.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<bool>("IsArchive");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<int?>("OwnerID");

                    b.Property<string>("UserPassword");

                    b.Property<string>("UserType");

                    b.HasIndex("OwnerID");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SunridgeHOA.Models.BoardMember", b =>
                {
                    b.HasOne("SunridgeHOA.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SunridgeHOA.Models.ClassifiedListing", b =>
                {
                    b.HasOne("SunridgeHOA.Models.ClassifiedCategory", "ClassifiedCategory")
                        .WithMany()
                        .HasForeignKey("ClassifiedCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SunridgeHOA.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SunridgeHOA.Models.CommonAreaAsset", b =>
                {
                    b.HasOne("SunridgeHOA.Models.MaintenanceRecord")
                        .WithMany("CommonAreaAsset")
                        .HasForeignKey("CommonAreaAssetID");
                });

            modelBuilder.Entity("SunridgeHOA.Models.File", b =>
                {
                    b.HasOne("SunridgeHOA.Models.OwnerHistory", "OwnerHistory")
                        .WithMany()
                        .HasForeignKey("OwnerHistoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SunridgeHOA.Models.InventoryItem", b =>
                {
                    b.HasOne("SunridgeHOA.Models.Lot")
                        .WithMany("InventoryItems")
                        .HasForeignKey("InventoryID");
                });

            modelBuilder.Entity("SunridgeHOA.Models.Key", b =>
                {
                    b.HasOne("SunridgeHOA.Models.KeyHistory", "KeyHistory")
                        .WithMany()
                        .HasForeignKey("KeyHistoryID");

                    b.HasOne("SunridgeHOA.Models.Owner")
                        .WithMany("KeyUnits")
                        .HasForeignKey("KeyUnitID");
                });

            modelBuilder.Entity("SunridgeHOA.Models.Lot", b =>
                {
                    b.HasOne("SunridgeHOA.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SunridgeHOA.Models.Owner")
                        .WithMany("Lots")
                        .HasForeignKey("LotsID");
                });

            modelBuilder.Entity("SunridgeHOA.Models.Owner", b =>
                {
                    b.HasOne("SunridgeHOA.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");

                    b.HasOne("SunridgeHOA.Models.Owner", "OwnerID")
                        .WithMany()
                        .HasForeignKey("CoOwnerID");

                    b.HasOne("SunridgeHOA.Models.Lot", "Lot")
                        .WithMany()
                        .HasForeignKey("LotID");
                });

            modelBuilder.Entity("SunridgeHOA.Models.OwnerContactType", b =>
                {
                    b.HasOne("SunridgeHOA.Models.ContactType", "ContactType")
                        .WithMany()
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SunridgeHOA.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SunridgeHOA.Models.OwnerHistory", b =>
                {
                    b.HasOne("SunridgeHOA.Models.HistoryType", "HistoryType")
                        .WithMany()
                        .HasForeignKey("HistoryTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SunridgeHOA.Models.Lot", "Lot")
                        .WithMany()
                        .HasForeignKey("LotID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SunridgeHOA.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SunridgeHOA.Models.Transaction", b =>
                {
                    b.HasOne("SunridgeHOA.Models.Lot", "Lot")
                        .WithMany()
                        .HasForeignKey("LotID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SunridgeHOA.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SunridgeHOA.Models.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SunridgeHOA.Models.ApplicationUser", b =>
                {
                    b.HasOne("SunridgeHOA.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID");
                });
#pragma warning restore 612, 618
        }
    }
}
