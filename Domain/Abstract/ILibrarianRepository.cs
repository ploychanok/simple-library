using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface ILibrarianRepository
    {
        IEnumerable<Librarian> Librarians { get; }
        void Add(Librarian librarian);
        void Replace(Librarian previous, Librarian current);
        void Delete(Librarian librarian);
        Librarian GetByID(int id);
    }
}
