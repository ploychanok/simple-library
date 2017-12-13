using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFRecordRepository : IRecordRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Record> Records
        {
            get { return context.Records; }
        }

        public IEnumerable<Book> AvailableBooks()
        {
            List<Book> list = new List<Book>();
            foreach (var item in context.Books)
            {
                if (item.Available == true)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public void Add(Record record)
        {
            context.Records.Add(record);
            context.SaveChanges();
        }

        public void Delete(Record record)
        {
            context.Records.Remove(record);
            context.SaveChanges();
        }

        public void Return(Record record)
        {
            GetByID(record.RecordID).Status = true;
            GetBookByID(Convert.ToInt32(record.BookID)).Available = true;
            context.SaveChanges();
        }

        public Record GetByID(int id)
        {
            foreach (var item in context.Records)
            {
                if (id == item.RecordID)
                {
                    return item;
                }
            }
            return null;
        }

        public void Replace(Record previous, Record current)
        {
            context.Records.Remove(previous);
            context.Records.Add(current);
            context.SaveChanges();
        }

        public Book GetBookByID(int id)
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

        public Member GetMemberByID(int id)
        {
            foreach (var item in context.Members)
            {
                if (id == item.MemberID)
                {
                    return item;
                }
            }
            return null;
        }

        public bool CheckValid(int bookID, int memberID)
        {
            if (GetBookByID(bookID) != null && GetBookByID(bookID).Available == true && GetMemberByID(memberID) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<Member> GetMembers()
        {
            return context.Members;
        }
    }
}
