using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class OwnerContactTypes
    {

        [ForeignKey("OwnerID")]
        public virtual int OwnerID { get; set; }

        [ForeignKey("ContactID")]
        public virtual int ContactID { get; set; }

        public int ID { get; set; }

        public string ContactValue { get; set; }

        public bool IsArchive { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
