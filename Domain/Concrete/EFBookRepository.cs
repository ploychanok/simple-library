using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFBookRepository : IBookRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Book> Books
        {
            get { return context.Books; }
        }

        public void Add(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void Delete(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
        }

        public Book GetByID(int id)
        {
            foreach (var item in context.Books)
            {
                if (id == item.BookID)
                {
                    return item;
                }
            }
            return null;
        }

        public IEnumerable<Book> GetSubList(string query, string criteria)
        {
            List<Book> list = new List<Book>();
            switch (criteria)
            {
                case "id":
                    foreach (var item in context.Books)
                    {
                        if (item.BookID.ToString().Equals(query))
                        {
                            list.Add(item);
                        }
                    }
                    break;
                case "title":
                    foreach (var item in context.Books)
                    {
                        if (item.Title.ToLower().Contains(query.ToLower()))
                        {
                            list.Add(item);
                        }
                    }
                    break;
                case "author":
                    foreach (var item in context.Books)
                    {
                        if (item.Author.ToLower().Contains(query.ToLower()))
                        {
                            list.Add(item);
                        }
                    }
                    break;
                case "publisher":
                    foreach (var item in context.Books)
                    {
                        if (item.Publisher.ToLower().Contains(query.ToLower()))
                        {
                            list.Add(item);
                        }
                    }
                    break;
                case "isbn":
                    foreach (var item in context.Books)
                    {
                        if (item.ISBN.Equals(query))
                        {
                            list.Add(item);
                        }
                    }
                    break;
                case "all":
                    foreach (var item in context.Books)
                    {
                        if (item.BookID.ToString().Equals(query))
                        {
                            list.Add(item);
                        }
                        else if (item.Title.ToLower().Contains(query.ToLower()))
                        {
                            list.Add(item);
                        }
                        else if (item.Author.ToLower().Contains(query.ToLower()))
                        {
                            list.Add(item);
                        }
                        else if (item.Publisher.ToLower().Contains(query.ToLower()))
                        {
                            list.Add(item);
                        }
                        else if (item.ISBN.ToLower().Equals(query.ToLower()))
                        {
                            list.Add(item);
                        }
                    }
                    break;
            }
            return list;
        }

        public void Replace(Book previous, Book current)
        {
            context.Books.Remove(previous);
            context.Books.Add(current);
            context.SaveChanges();
        }
    }
}
