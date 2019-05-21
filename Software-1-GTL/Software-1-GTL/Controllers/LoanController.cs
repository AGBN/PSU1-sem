using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.DataAccess;
using GTL.Factories;

namespace GTL.Controllers
{
    public class LoanController : IController
    {
        public IDataAccess DataAccess { get; }

        public LoanController(IDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }

        public IModel Get(params int[] id)
        {
            throw new NotImplementedException();
        }

        public IModel Get(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }

        public Loan Create(Member member, Librarian librarian, ICollection<Book> books)
        {
            //TODO finish implementation

            // Instantiate variables
            Loan l;
            ICollection<LoanBook> lbList;

            MemberController    mCtr = (MemberController)FactoryController.Instance.Create("Member");
            LibrarianController libCtr = (LibrarianController)FactoryController.Instance.Create("librarian");
            BookController      bCtr = (BookController)FactoryController.Instance.Create("book");


            // Check if objects exists and requirements have been met.

            
            
            // Create objects
            lbList = FactoryModels.CreateLoanBookList(books);

            l = FactoryModels.CreateLoan(librarian, member, lbList);

            // Insert into database
            l = (Loan)DataAccess.Insert(l);

            // Create additional objects if needed


            // return created object
            return l;
        }
    }
}
