using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models.ViewModels
{
    public class MyLotsViewModel
    {
        public Owner Owner { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
        public IEnumerable<OwnerHistory> OwnerHistories { get; set; }
    }
}
