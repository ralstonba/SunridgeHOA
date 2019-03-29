using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models.ViewModels
{
    public class BoardMembersViewModel
    {
        public BoardMember BoardMember { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}
