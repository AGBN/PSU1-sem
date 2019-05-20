using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Controllers;
using GTL.DataAccess;

namespace GTL.Factories
{
    public class Factory : IFactory
    {

        public IController CreateController(string NameOfController)
        {
            IController controller;

            switch (NameOfController.ToLower())
            {
                case "member":
                    controller = new MemberController(this);
                    break;

                default:
                    throw new ArgumentException("No controller exists for name " + NameOfController);
            }

            return controller;

        }

        public IDataAccess CreateDataAccess(string NameOfDataAcces)
        {
            IDataAccess dataAcces;

            switch (NameOfDataAcces.ToLower())
            {
                case "member":
                    dataAcces = new MemberDataAccess(this);
                    break;

                default:
                    throw new ArgumentException("No Access class exists for name " + NameOfDataAcces);
            }

            return dataAcces;
        }

        public IModelFactory CreateModelFactory()
        {
            return new GTL.Factories.ModelFactory();
        }

    }
}
