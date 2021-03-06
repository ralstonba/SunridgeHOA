﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SunridgeHOA.Models;

namespace SunridgeHOA.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<ClassifiedCategory> ClassifiedCategories { get; set; }
        public DbSet<ClassifiedListing> ClassifiedListings { get; set; }
        public DbSet<CommonAreaAsset> CommonAreaAssets { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<HistoryType> HistoryTypes { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<KeyHistory> KeyHistories { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<OwnerContactType> OwnerContactTypes { get; set; }
        public DbSet<OwnerHistory> OwnerHistories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ScheduledEvent> ScheduledEvents { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Banner> Banner { get; set; }
    }
}
