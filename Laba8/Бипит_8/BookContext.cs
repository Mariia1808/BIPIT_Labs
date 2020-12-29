using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Бипит_8
{
    public class BookContext : DbContext
    {
        public BookContext() : base("DBConnection") { }

        public DbSet<Book> Book { get; set; }
    }
}