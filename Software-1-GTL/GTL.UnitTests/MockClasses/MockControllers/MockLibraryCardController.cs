using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.Controllers;
using GTL.DataAccess;

namespace GTL.UnitTests.MockClasses.MockControllers
{
    class MockLibraryCardController : LibraryCardController
    {
        public MockLibraryCardController(IDataAccess dataAccess) : base(dataAccess)
        {
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

        public override LibraryCard Create()
        {
            return new LibraryCard();
        }
    }
}
