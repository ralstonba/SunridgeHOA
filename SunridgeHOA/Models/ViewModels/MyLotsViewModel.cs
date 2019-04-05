using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models.ViewModels
{
    public class MyLotsViewModel
    {
        public int OwnerID { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
    }
}
