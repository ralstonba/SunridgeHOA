using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class Lot
    {
        [Key] // Primary Key
        public int ID { get; set; }

        public string LotNumber { get; set; }

        public string Status { get; set; }

        public bool IsArchive { get; set; }

        public DateTime LastModifiedDate { get; set; }
        public string TaxID { get; set; }

        // Navigation Properties
        public int InventoryID { get; set; }
        [ForeignKey("InventoryID")]
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }

        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }

        [NotMapped]
        public int OwnerID { get; set; }
        [NotMapped]
        public virtual Owner Owner { get; set; }

    }
}
