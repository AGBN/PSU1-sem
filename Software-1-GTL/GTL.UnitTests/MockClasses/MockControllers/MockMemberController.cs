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
    public class MockMemberController : MemberController
    {
        public MockMemberController(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public override IModel Get(params int[] id)
        {
            return null;
        }

        public override IModel Get(string id)
        {
            throw new NotImplementedException();

        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
