using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Бипит_8
{
    public class FIOContext : DbContext
    {
        public FIOContext() : base("DBConnection") { }

        public DbSet<FIO> FIO { get; set; }
    }
}