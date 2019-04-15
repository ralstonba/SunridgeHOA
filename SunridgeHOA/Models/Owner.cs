using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class Owner
    {
        [Key]   // Primary Key
        public int ID { get; set; }

        public bool IsPrimary { get; set; }

        public bool IsBoardMember { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Image { get; set; }

        public string Occupation { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public  bool? IsArchive { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        //Navigation Properties
        [ForeignKey("Address")]
        public int? AddressID { get; set; }
        public virtual Address Address { get; set; }

        [ForeignKey("OwnerID")]
        public int? CoOwnerID { get; set; }
        public virtual Owner OwnerID { get; set; }

        [ForeignKey("LotID")]
        public int? LotID { get; set; }
        public virtual Lot Lot { get; set; }

        public int LotsID { get; set; }
        [ForeignKey("LotsID")]
        public virtual ICollection<Lot> Lots { get; set; }

        public int? KeyUnitID { get; set; }
        [ForeignKey("KeyUnitID")]
        public virtual ICollection<Key> KeyUnits { get; set; }
    }
}
