using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBAAccountAPI.Models
{
    public class SBAAccountDBContext:DbContext
    {
        public SBAAccountDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SBAAccount> accounts { get; set; }
    }
}
