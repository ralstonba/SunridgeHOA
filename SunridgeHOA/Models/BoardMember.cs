using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class BoardMember
    {
        public int ID { get; set; }
        public string Position { get; set; }

        //Navigation Properties
        [ForeignKey("Owner")]
        public int OwnerID { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
