﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class Lot
    {
        [Key]
        public int ID { get; set; }

        public string LotNumber { get; set; }

        public string Status { get; set; }

        public bool IsArchive { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        // Navigation Properties
        [ForeignKey("InventoryItem")] public int InventoryID { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }

        [ForeignKey("AddressID")]
        public int AddressID { get; set; }
        public virtual Address Addresses { get; set; }

        [ForeignKey("OwnerID")]
        public int OwnerID { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
