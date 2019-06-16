using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.DataAccess
{
    public class MemberAccess : IAccess
    {
        public object Get(int id)
        {
            Member m;
            using (var context = new GTL_Entities())
            {
                var query = from member in context.Members
                            where member.IsActive == true
                            select member;

                m = query.FirstOrDefault();
            }

            return new NotFiniteNumberException();
        }
    }
}
