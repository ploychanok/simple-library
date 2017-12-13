using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFLibrarianRepository : ILibrarianRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Librarian> Librarians
        {
            get { return context.Librarians; }
        }

        public void Add(Librarian librarian)
        {
            context.Librarians.Add(librarian);
            context.SaveChanges();
        }

        public void Delete(Librarian librarian)
        {
            context.Librarians.Remove(librarian);
            context.SaveChanges();
        }

        public Librarian GetByID(int id)
        {
            foreach (var item in context.Librarians)
            {
                if (id == item.LibrarianID)
                {
                    return item;
                }
            }
            return null;
        }

        public void Replace(Librarian previous, Librarian current)
        {
            context.Librarians.Remove(previous);
            context.Librarians.Add(current);
            context.SaveChanges();
        }
    }
}
