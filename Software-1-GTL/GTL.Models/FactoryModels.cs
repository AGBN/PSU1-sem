using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Interfaces;
using GTL.Models;

namespace GTL.Factories
{
    public class FactoryModels : IFactory
    {
        public T Create<T>(string nameOfObject)
        {
            IModel model;
            T result = default(T);

            switch (nameOfObject.ToLower())
            {
                case "member":
                    model = new Member();
                    break;

                default:
                    throw new ArgumentException("No controller could be found using the name: " + nameOfObject);
            }

            try
            {
                result = (T)model;
            }
            catch (Exception e)
            {
                string s = e.StackTrace;
                throw new InvalidCastException("Could not cast " + model.GetType() + " to " + result.GetType());
            }

            return result;

        }
    }
}
