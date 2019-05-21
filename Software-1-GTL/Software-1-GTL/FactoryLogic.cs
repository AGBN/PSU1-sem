using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;
using GTL.Controllers;
using GTL.Logic;

namespace GTL.Factories
{
    public class FactoryLogic : IFactoryLogic
    {
        private static IFactoryLogic instance;

        public static IFactoryLogic Instance
        {
            get
            {
                if (instance == null)
                    instance = new FactoryLogic();

                return instance;
            }


            set { instance = value; }
        }

        public ILogic Create(string nameOfObject)
        {
            ILogic logic;

            switch (nameOfObject.ToLower())
            {

                case "librarian":
                    logic = new LibrarianLogic();
                    break;


                default:
                    throw new ArgumentException("No controller could be found using the name: " + nameOfObject);
            }

            return logic;
        }

    }
}
