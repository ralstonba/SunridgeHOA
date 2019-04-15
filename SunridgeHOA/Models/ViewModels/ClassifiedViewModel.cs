using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models.ViewModels
{
    public class ClassifiedViewModel
    {
        public ClassifiedListing Lots { get; set; }
        public ClassifiedListing Cabins { get; set; }
        public Service Service { get; set; }
    }
}
