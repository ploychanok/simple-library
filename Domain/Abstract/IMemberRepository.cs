using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IMemberRepository
    {
        IEnumerable<Member> Members { get; }
        void Add(Member member);
        void Replace(Member previous, Member current);
        void Delete(Member member);
        Member GetByID(int id);
    }
}
