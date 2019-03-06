using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class ContactTypes
    {
        public int ID { get; set; }

        public string Value { get; set; }

        public bool IsArchive { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
