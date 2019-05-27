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
    public class MockBookController : BookController
    {
        public MockBookController(IDataAccess dataAccess) : base(dataAccess)
        {

        }

        public object Action(string actionName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params string[] id)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params int[] id)
        {
            throw new NotImplementedException();
        }

        public IModel Insert(IModel model)
        {
            throw new NotImplementedException();
        }

        public override bool IsAllAvailable(ICollection<Book> books)
        {
            foreach (var item in books)
            {
                if (item.Available == false)
                    return false;


            }
            return true;
        }
    }
}
