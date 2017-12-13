using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFMemberRepository : IMemberRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Member> Members
        {
            get { return context.Members; }
        }

        public void Add(Member member)
        {
            context.Members.Add(member);
            context.SaveChanges();
        }

        public void Delete(Member member)
        {
            context.Members.Remove(member);
            context.SaveChanges();
        }

        public Member GetByID(int id)
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

        public void Replace(Member previous, Member current)
        {
            context.Members.Remove(previous);
            context.Members.Add(current);
            context.SaveChanges();
        }
    }
}
