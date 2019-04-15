using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class Key
    {
        [Key]   // Primary Key
        public int ID { get; set; }

        public string SerialNumber { get; set; }

        public bool IsArchive { get; set; }

        public DateTime LastModifiedDate { get; set; }

        //Navigation Properties
        public int? KeyHistoryID { get; set; }
        [ForeignKey("KeyHistoryID")]
        public virtual KeyHistory KeyHistory { get; set; }
    }
}
