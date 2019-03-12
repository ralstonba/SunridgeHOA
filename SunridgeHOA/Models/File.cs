using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class File
    {
        [Key] public int ID { get; set; }
        public bool IsMainImage { get; set; }
        [Required]
        public string FileURL { get; set; }
        public string ImageContentType { get; set; }
        [Required]
        public string FileType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public bool IsArchive { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }

        // Navigation Properties
        [ForeignKey("OwnerHistory")] public int OwnerHistoryID { get; set; }
        public OwnerHistory OwnerHistory { get; set; }

        [Required, ForeignKey("ApplicationUser")] public int LastModifiedBy { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
