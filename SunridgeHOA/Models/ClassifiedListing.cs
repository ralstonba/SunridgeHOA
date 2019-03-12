using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class ClassifiedListing
    {
        [Key] public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime ListingDate { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public bool IsArchive { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }

        // Navigation Properties
        [Required, ForeignKey("Owner")] public int OwnerID { get; set; }
        public Owner Owner { get; set; }

        [Required, ForeignKey("ClassifiedCategory")] public int ClassifiedCategoryID { get; set; }
        public ClassifiedCategory ClassifiedCategory { get; set; }

        [Required, ForeignKey("ApplicationUser")] public int LastModifiedBy { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
