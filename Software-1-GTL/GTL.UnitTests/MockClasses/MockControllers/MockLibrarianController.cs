using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Controllers;
using GTL.DataAccess;
using GTL.Models;

namespace GTL.UnitTests.MockClasses.MockControllers
{
    public class MockLibrarianController : LibrarianController
    {
        public MockLibrarianController(IDataAccess dataAccess) : base(dataAccess)
        {
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

        public override Librarian Create(Member m, string username, string password, LibrarianRole role)
        {
            return new Librarian();
        }

        public override bool HasPermission(Librarian librarian, string permission)
        {

            if (permission.Equals("Loan"))
                permission = "CheckOut";

            if (librarian.LibrarianRole.Equals(permission))
                return true;
            else
                return false;
        }
    }
}
