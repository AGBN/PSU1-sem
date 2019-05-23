using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.DataAccess
{
    public class MemberTypeDataAccess : IDataAccess
    {
        public object Action(string actionName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params int[] id)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params string[] id)
        {
            MemberType mt = null;

            using (var context = new GTL_Entities())
            {
                var query = context.MemberTypes.Find(id[0]);

                mt = query;
            }

            return mt;
        }

        public IModel Insert(IModel model)
        {
            throw new NotImplementedException();
        }
    }
}
