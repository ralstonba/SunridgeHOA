using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class MaintenanceRecord
    {
        [Key] public int ID { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsArchive { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }

        // Navigation Properties
        [Required, ForeignKey("CommonAreaAsset")] public int CommonAreaAssetID { get; set; }
        public virtual ICollection<CommonAreaAsset> CommonAreaAsset { get; set; }

        [Required, ForeignKey("User")] public int UserID { get; set; }
        public User User { get; set; }
    }
}
