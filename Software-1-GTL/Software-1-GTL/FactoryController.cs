using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;

namespace GTL.Controllers
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
                /*case "loan":
                    controller = new LoanController();
                    break;
                    
                case "book":
                    controller = new BookController();
                    break;*/

                case "member":
                    if (dataAccess == null)
                        controller = new MemberController(null);
                    else
                        controller = new MemberController(dataAccess);

                    break;

                default:
                    throw new ArgumentException("No controller could be found using the name: " + nameOfObject);
            }

            return controller;
        }

    }
}
