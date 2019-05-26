using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;
using GTL.Controllers;
using GTL.Factories;
using GTL.UnitTests.MockClasses;
using GTL.UnitTests.MockClasses.MockControllers;

namespace GTL.UnitTests
{
    public class MockFactoryController : IFactoryController
    {
        public IController Create(string nameOfObject, IDataAccess dataAccess = null)
        {
            IController controller;

            switch (nameOfObject.ToLower())
            {

                case "member":
                    controller = new MockMemberController(null);
                    break;


                case "address":
                        controller = new MockAddressController(null);
                    break;


                case "membertype":
                        controller = new MockMemberTypeController(null);
                    break;


                case "librarycard":
                        controller = new MockLibraryCardController(null);
                    break;

                case "librarian":
                    if (dataAccess == null)
                        controller = new MockLibrarianController(null);
                    else
                        controller = new MockLibrarianController(dataAccess);
                    break;

                //case "loan":
                //    if (dataAccess == null)
                //        controller = new LoanController(FactoryDataAccess.Instance.Create("loan"));
                //    else
                //        controller = new LoanController(dataAccess);
                //    break;

                case "book":
                    if (dataAccess == null)
                        controller = new MockBookController(null);
                    else
                        controller = new MockBookController(dataAccess);
                    break;

                default:
                    throw new ArgumentException("No controller could be found using the name: " + nameOfObject);
            }

            return controller;
        }

    }
}
