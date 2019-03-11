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
        [Key]
        public int ID { get; set; }

        [ForeignKey("LastModifiedBy")]
        public virtual string LastModifiedBy { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string UserType { get; set; }

        public bool IsArchive { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
