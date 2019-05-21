using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;
using GTL.Factories;
using GTL.UnitTests.MockClasses;
using GTL.UnitTests.MockClasses.MockDataAccess;

namespace GTL.UnitTests
{
    public class MockFactoryDataAccess : IFactoryDataAccess
    {
        public IDataAccess Create(string nameOfDataAccess)
        {
            IDataAccess dataAccess;

            switch (nameOfDataAccess.ToLower())
            {

                case "member":
                    dataAccess = new MockMemberDataAccess();
                    break;


                case "address":
                    dataAccess = new MockAddressDataAccess();
                    break;


                case "membertype":
                    dataAccess = new MockMemberTypeDataAccess();
                    break;


                //case "librarycard":
                //    dataAccess = new MockLibraryCardDataAccess();
                //    break;


                //case "librarian":
                //    dataAccess = new MockLibrarianDataAccess();
                //    break;


                //case "loan":
                //    dataAccess = new MockLoanDataAccess();
                //    break;


                //case "book":
                //    dataAccess = new MockBookDataAccess();
                //    break;


                default:
                    throw new ArgumentException("No DataAccess class could be found using the name: " + nameOfDataAccess);
            }

            return dataAccess;
        }
    }
}
