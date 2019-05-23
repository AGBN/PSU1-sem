using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;
using GTL.Controllers;

namespace GTL.Factories
{
    public class FactoryController : IFactoryController
    {
        private static IFactoryController instance;

        public static IFactoryController Instance
        {
            get
            {
                if (instance == null)
                    instance = new FactoryController();

                return instance;
            }


            set { instance = value; }
        }

        public IController Create(string nameOfObject, IDataAccess dataAccess = null)
        {
            IController controller;

            switch (nameOfObject.ToLower())
            {

                case "member":
                    if (dataAccess == null)
                        controller = new MemberController(FactoryDataAccess.Instance.Create("member"));
                    else
                        controller = new MemberController(dataAccess);
                    break;


                case "address":
                    if (dataAccess == null)
                        controller = new AddressController(FactoryDataAccess.Instance.Create("address"));
                    else
                        controller = new AddressController(dataAccess);
                    break;


                case "membertype":
                    if (dataAccess == null)
                        controller = new MemberTypeController(FactoryDataAccess.Instance.Create("membertype"));
                    else
                        controller = new MemberTypeController(dataAccess);
                    break;


                case "librarycard":
                    if (dataAccess == null)
                        controller = new LibraryCardController(FactoryDataAccess.Instance.Create("librarycard"));
                    else
                        controller = new LibraryCardController(dataAccess);
                    break;

                case "librarian":
                    if (dataAccess == null)
                        controller = new LibrarianController(FactoryDataAccess.Instance.Create("librarian"));
                    else
                        controller = new LibrarianController(dataAccess);
                    break;

                case "loan":
                    if (dataAccess == null)
                        controller = new LoanController(FactoryDataAccess.Instance.Create("loan"));
                    else
                        controller = new LoanController(dataAccess);
                    break;

                case "book":
                    if (dataAccess == null)
                        controller = new BookController(FactoryDataAccess.Instance.Create("book"));
                    else
                        controller = new BookController(dataAccess);
                    break;

                case "title":
                    if (dataAccess == null)
                        controller = new TitleController(FactoryDataAccess.Instance.Create("title"));
                    else
                        controller = new TitleController(dataAccess);
                    break;


                default:
                    throw new ArgumentException("No controller could be found using the name: " + nameOfObject);
            }

            return controller;
        }

    }
}
