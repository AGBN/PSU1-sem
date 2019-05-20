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

        public IModel Get(string id)
        {
            // TODO Implement this properly
            MemberType mt = new MemberType();

            mt.GracePeriod = 12;
            mt.LoanPeriod = 32;
            mt.MaxBooksLoaned = 2;
            mt.TypeName = "Student";

            return mt;
        }

        public IModel Insert(IModel model)
        {
            throw new NotImplementedException();
        }
    }
}
