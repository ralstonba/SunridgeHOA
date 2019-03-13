using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class OwnerHistory
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsArchive { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }

        // Navigation Properties
        [Required, ForeignKey("Lot")]
        public int LotID { get; set; }
        public virtual Lot Lot { get; set; }

        [Required, ForeignKey("Owner")]
        public int OwnerID { get; set; }
        public virtual Owner Owner { get; set; }

        [Required, ForeignKey("HistoryType")]
        public int HistoryTypeID { get; set; }
        public virtual HistoryType HistoryType { get; set; }

        [Required, ForeignKey("ApplicationUser")] public int LastModifiedBy { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
