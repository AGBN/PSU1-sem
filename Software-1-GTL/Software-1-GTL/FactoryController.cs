using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Controllers;
using GTL.Interfaces;

namespace GTL.Factories
{
    public class FactoryController : IFactory
    {

        public T Create<T>(string nameOfObject)
        {
            IController controller;
            T result = default(T);

            switch (nameOfObject.ToLower())
            {
                /*case "loan":
                    controller = new LoanController();
                    break;
                    
                case "book":
                    controller = new BookController();
                    break;*/

                case "member":
                    controller = new MemberController();
                    break;

                default:
                    throw new ArgumentException("No controller could be found using the name: " + nameOfObject);
            }


            try
            {
                result = (T)controller;
            }
            catch (Exception e)
            {
                string s = e.StackTrace;
                throw new InvalidCastException("Could not cast " + controller.GetType() + " to " +  result.GetType());
            }

            return result;
        }
    }
}
