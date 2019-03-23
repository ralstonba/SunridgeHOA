using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class ContactType
    {
        [Key]   // Primary Key
        public int ID { get; set; }

        public string Value { get; set; }

        public bool IsArchive { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
