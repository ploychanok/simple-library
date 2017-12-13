using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
        void Add(Book book);
        void Replace(Book previous, Book current);
        void Delete(Book book);
        Book GetByID(int id);
        IEnumerable<Book> GetSubList(string query, string criteria);
    }
}
