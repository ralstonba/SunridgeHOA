using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class Transactions
    {
        [ForeignKey("LotID")]
        public virtual int LotID { get; set; }

        [ForeignKey("OwnerID")]
        public virtual int OwnerID { get; set; }

        [ForeignKey("TransactionTypeID")]
        public virtual int TransactionTypeID { get; set; }

        public int ID { get; set; }

        public string Description { get; set; }

        public float Amount { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DatePaid { get; set; }

        public string Status { get; set; }

        public bool IsArchive { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
