using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Бипит_8
{
    public class Arenda_bookContext : DbContext
    {
        public Arenda_bookContext() : base("DBConnection") { }

        public DbSet<Arenda_book> Arenda_book { get; set; }
    }
}