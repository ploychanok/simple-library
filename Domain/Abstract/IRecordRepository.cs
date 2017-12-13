using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IRecordRepository
    {
        IEnumerable<Record> Records { get; }
        void Add(Record record);
        void Replace(Record previous, Record current);
        void Delete(Record record);
        Record GetByID(int id);
        Book GetBookByID(int id);
        Member GetMemberByID(int id);
        void Return(Record record);
        bool CheckValid(int bookID, int memberID);
        IEnumerable<Book> AvailableBooks();
        IEnumerable<Member> GetMembers();
    }
}
