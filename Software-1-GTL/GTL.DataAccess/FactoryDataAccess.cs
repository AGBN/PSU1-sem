using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;

namespace GTL.Factories
{
    public class FactoryDataAccess : IFactoryDataAccess
    {
        private static IFactoryDataAccess instance;

        public static IFactoryDataAccess Instance
        {
            get
            {
                if (instance == null)
                    instance = new FactoryDataAccess();

                return instance;
            }


            set { instance = value; }
        }

        public IDataAccess Create(string nameOfDataAccess)
        {
            IDataAccess dataAccess;

            switch (nameOfDataAccess.ToLower())
            {

                case "member":
                    dataAccess = new MemberDataAccess();
                    break;


                case "address":
                    dataAccess = new AddressDataAccess();
                    break;


                case "membertype":
                    dataAccess = new MemberTypeDataAccess();
                    break;


                case "librarycard":
                    dataAccess = new LibraryCardDataAccess();
                    break;


                case "librarian":
                    dataAccess = new LibrarianDataAccess();
                    break;


                case "loan":
                    dataAccess = new LoanDataAccess();
                    break;


                case "book":
                    dataAccess = new BookDataAccess();
                    break;

                case "title":
                    dataAccess = new TitleDataAccess();
                    break;

                default:
                    throw new ArgumentException("No DataAccess class could be found using the name: " + nameOfDataAccess);
            }

            return dataAccess;
        }
    }
}
