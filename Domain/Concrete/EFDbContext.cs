using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}
