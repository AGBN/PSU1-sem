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

        public IModel Get(params string[] id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }

        public Loan Create(Member member, Librarian librarian, ICollection<Book> books)
        {
            // Instantiate variables
            MemberController mCtr = (MemberController)FactoryController.Instance.Create("member");
            LibrarianController lCtr = (LibrarianController)FactoryController.Instance.Create("librarian");
            BookController bCtr = (BookController)FactoryController.Instance.Create("book");
            Loan l ;
            ICollection<LoanBook> lbList;
            DateTime dateCreated = DateTime.UtcNow;

            // Check if objects exists and requirements have been met.
            if (mCtr.CanLoan(member) == false)
                throw new ArgumentException("This member cannot loan anymore items.");

            if (lCtr.HasPermission(librarian, "Loan") == false)
                throw new ArgumentException("This librarian does not have permission to create loans.");

            if (bCtr.IsAllAvailable(books) == false)
                throw new ArgumentException("One or more books are not available for loan.");

            // Create objects
            lbList = FactoryModels.CreateLoanBookList(books);

            l = FactoryModels.CreateLoan(librarian, member, lbList, dateCreated);

            // Insert into database
            l = (Loan)DataAccess.Insert(l);

            // Create additional objects if needed


            // return created object
            return l;
        }
    }
}
