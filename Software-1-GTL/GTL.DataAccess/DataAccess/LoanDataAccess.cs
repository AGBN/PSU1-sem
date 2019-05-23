using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.DataAccess
{
    public class LoanDataAccess : IDataAccess
    {
        public object Action(string actionName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params int[] id)
        {
            // TODO implement properly

            throw new NotImplementedException();
        }

        public IModel Get(string id)
        {
            throw new NotImplementedException();
        }

        public IModel Insert(IModel model)
        {
            Loan loanDb, loanNew;

            loanNew = (Loan)model;

            //Username is unique.

            using (var context = new GTL_Entities())
            {
                loanDb = context.Loans.Add(loanNew);

                context.SaveChanges();
            }

            return loanDb;
        }
    }
}
