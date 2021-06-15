using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBAAccountAPI.Models
{
    public class SBAAccount
    {
        [Key]
        public int accountNumber { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }
        public double currentBalance { get; set; }
    }
}
