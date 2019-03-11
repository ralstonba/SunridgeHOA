using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class Owner
    {
        [ForeignKey("AddressID")]
        public virtual Addresses AddressID { get; set; }

        [ForeignKey("CoOwnerID")]
        public virtual Addresses CoOwnerID { get; set; }

        public int ID { get; set; }

        public bool IsPrimary { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Occupation { get; set; }

        public DateTime Birthday { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public  bool IsArchive { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
