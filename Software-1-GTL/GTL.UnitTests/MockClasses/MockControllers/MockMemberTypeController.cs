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
    class MockMemberTypeController : MemberTypeController
    {
        public MockMemberTypeController(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public IModel Get(params int[] id)
        {
            throw new NotImplementedException();
        }

        public override IModel Get(string id)
        {
            return new MemberType() { TypeName = "Student", GracePeriod = 1, LoanPeriod = 4, MaxBooksLoaned = 5};
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
