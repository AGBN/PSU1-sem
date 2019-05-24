using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.DataAccess
{
    public class MemberDataAccess : IDataAccess
    {
        public object Action(string actionName, params object[] args)
        {
            return true;
        }

        public IModel Get(params int[] id)
        {
            Member m;

            using (var context = new GTL_Entities())
            {
                var query = context.Members.Find(id.First());

                m = query;
            }

            return m;
        }

        public IModel Get(params string[] id)
        {
            throw new NotImplementedException();
        }

        public IModel Insert(IModel model)
        {
            Member m, newM = (Member)model;

            newM.MemberType = null;

            using (var context = new GTL_Entities())
            {
                m = context.Members.Add((Member)model);
                context.SaveChanges();
            }

            return m;
        }
    }
}
