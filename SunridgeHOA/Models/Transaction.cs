using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class Transaction
    {
        [Key]   // Primary Key
        public int ID { get; set; }

        public string Description { get; set; }

        public float Amount { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DatePaid { get; set; }

        public string Status { get; set; }

        public bool IsArchive { get; set; }

        public DateTime LastModifiedDate { get; set; }

        // Foreign Keys
        [ForeignKey("Lot")]
        public int LotID { get; set; }
        public virtual Lot Lot { get; set; }

        [ForeignKey("Owner")]
        public int OwnerID { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }
        public virtual TransactionType TransactionType { get; set; }

        [ForeignKey("ApplicationUser")]
        public int LastModifiedBy { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
