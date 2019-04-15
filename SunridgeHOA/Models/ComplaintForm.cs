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
        [ForeignKey("Owner")]
        public int OwnerID { get; set; }
        public virtual Owner Owner { get; set; }
        [ForeignKey("States")]
        public int StatesID { get; set; }
        public virtual States States { get; set; }
    }
}
