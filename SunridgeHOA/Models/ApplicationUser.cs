using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserPassword { get; set; }

        public string UserType { get; set; }

        public bool IsArchive { get; set; }

        public DateTime LastModifiedDate { get; set; }
        [NotMapped] public bool IsSuperAdmin { get; set; }
    }
}
