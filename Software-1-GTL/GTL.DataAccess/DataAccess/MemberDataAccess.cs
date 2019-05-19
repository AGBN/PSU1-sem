using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.Interfaces;

namespace GTL.DataAccess
{
    public class MemberDataAccess : IDataAccess
    {
        public IFactory Factory { get; }

        public MemberDataAccess(IFactory factory)
        {
            this.Factory = factory;
        }

        public object Get(int id)
        {
            // TODO finish MemberGet Access method

            Member m;
            /*using (var context = new GTL_Entities())
            {
                var query = from x in context.Members
                            where x.IsActive == true
                            select x;

                m = query.FirstOrDefault();
            }*/

            m = new Member();
            m.FirstName = "HEJ";
            return m;
        }

        public void Create<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}
