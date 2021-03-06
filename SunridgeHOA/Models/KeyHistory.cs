﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Models
{
    public class KeyHistory
    {
        [Key]   // Primary Key
        public int ID { get; set; }

        public string Status { get; set; }

        public DateTime DateIssued { get; set; }

        public DateTime DateReturned { get; set; }

        public decimal PaidAmount { get; set; }

        public bool IsArchive { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
