using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class HistoryType
    {
        [Key] public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsArchive { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }

        // Navigation Properties
        [Required, ForeignKey("User")] public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
