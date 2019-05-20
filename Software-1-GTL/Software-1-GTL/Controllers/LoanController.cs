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

        public Loan Create(int borrowerSSN, int librarianSSN, ICollection<int> bookIDs)
        {
            //TODO finish implementation

            // Instantiate variables
            Loan l;

            MemberController    mCtr = (MemberController)FactoryController.Instance.Create("Member");
            LibrarianController libCtr = (LibrarianController)FactoryController.Instance.Create("librarian");
            BookController      bCtr = (BookController)FactoryController.Instance.Create("book");

            List<Book> bookList = new List<Book>();

            // Check if objects exists and requirements have been met.
            if (mCtr.Get(borrowerSSN) == null)
                throw new ArgumentException("Member doesnt exist");

            if (libCtr.Get(librarianSSN) == null)
                throw new ArgumentException("Librarian doesnt exist.");

            if (bookIDs.Count < 1)
                throw new ArgumentException("A loan must have at least one book.");

            foreach (int item in bookIDs)
            {
                Book b = (Book)bCtr.Get(item);
                if (b == null)
                    throw new ArgumentException("Book doesnt exist.");
                else
                    bookList.Add(b);
            }

            // Create objects
            l = FactoryModels.CreateLoan();
            l.Member = (Member)mCtr.Get(borrowerSSN);
            l.Librarian = (Librarian)libCtr.Get(librarianSSN);

            foreach (Book item in bookList)
            {
                LoanBook lb = FactoryModels.CreateLoanBook();

                //TODO move this into the factory method
                lb.BookID = item.TitleID;
                lb.CopyNr = item.CopyNr;

                l.LoanBooks.Add(lb);
            }

            // Insert into database
            try
            {
                l = (Loan)DataAccess.Insert(l);
            }
            catch (Exception e)
            {
                throw e;
            }

            // Create additional objects if needed


            // return created object
            return l;
        }
    }
}
