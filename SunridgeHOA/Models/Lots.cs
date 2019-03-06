using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class Lots
    {
        public int ID { get; set; }

        [ForeignKey("AddressID")]
        public virtual int AddressID { get; set; }

        [ForeignKey("OwnerID")]
        public virtual int OwnerID { get; set; }

        public string LotNumber { get; set; }

        public string Status { get; set; }

        public bool IsArchive { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
