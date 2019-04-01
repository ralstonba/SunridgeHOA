using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models.ViewModels
{
    public class BoardMemberIndexVM
    {
        public BoardMemberIndexVM(BoardMember boardMember, ApplicationUser user)
        {
            BoardMember = boardMember;
            User = user;
        }

        public BoardMember BoardMember { get; set; }
        public ApplicationUser User { get; set; }

        public string FullName()
        {
            return $"{BoardMember.Owner.FirstName} {BoardMember.Owner.LastName}";
        }
    }
}
