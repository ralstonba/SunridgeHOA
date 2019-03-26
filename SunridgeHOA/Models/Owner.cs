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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Occupation { get; set; }

        public DateTime Birthday { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public  bool IsArchive { get; set; }

        public DateTime LastModifiedDate { get; set; }

        //Navigation Properties
        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }

        [ForeignKey("OwnerID")]
        public int CoOwnerID { get; set; }
        public virtual Owner OwnerID { get; set; }
    }
}
