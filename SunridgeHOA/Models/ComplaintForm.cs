using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class ComplaintForm
    {
        [Key]   
        public int ID { get; set; }
        public string Description { get; set; }
        public string Suggestion { get; set; }
        [NotMapped]
        public int OwnerID { get; set; }
        [NotMapped]
        public virtual Owner Owner { get; set; }
        [NotMapped]
        public int StatesID { get; set; }
        public virtual States States { get; set; }
    }
}
