using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SunridgeHOA.Models
{
    public class InventoryItem
    {
        [Key] public int ID { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsArchive { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }

        // Navigation Properties
        [Required, ForeignKey("ApplicationUser")] public int LastModifiedBy { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
