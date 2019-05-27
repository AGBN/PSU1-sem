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

        public IModel Get(params string[] id)
        {
            throw new NotImplementedException();
        }
        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }
        public IModel Insert(IModel model)
        {
            Loan loanDb, loanNew = (Loan)model;

            loanNew.Member = null ;
            loanNew.Librarian = null;

            foreach (LoanBook item in loanNew.LoanBooks)
            {
                item.Book = null;
                item.Loan = null;
            }

            using (var context = new GTL_Entities())
            {
                loanDb = context.Loans.Add((Loan)model);

                context.SaveChanges();
            }

            return loanDb;
        }
    }
}
