using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class OwnerContactType
    {
        [Key]   // Primary Key
        public int ID { get; set; }

        public string ContactValue { get; set; }

        public bool IsArchive { get; set; }

        public DateTime LastModifiedDate { get; set; }

        // Navigation Properties
        [ForeignKey("OwnerID")]
        public int OwnerID { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("ContactID")]
        public int ContactID { get; set; }
        public virtual ContactType ContactType { get; set; }

        [ForeignKey("LastModifiedBy")]
        public int LastModifiedBy { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
