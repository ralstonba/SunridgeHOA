using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models.ViewModels
{
    public class OwnerViewModel
    {
        public Owner Owner { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
        public IEnumerable<Key> Keys { get; set; }
    }
}
