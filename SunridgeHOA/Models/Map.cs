using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class Map
    {
        [Key] public int ID { get; set; }
        [Required]
        public string FileURL { get; set; }
    }
}
