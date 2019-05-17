using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Interfaces;
using GTL.DataAccess;

namespace GTL.Factories
{
    public class FactoryAccess : IFactory
    {
        public T Create<T>(string nameOfObject)
        {
            IAccess access;
            T result = default(T);

            switch (nameOfObject.ToLower())
            {
                case "member":
                    access = new MemberAccess();
                    break;

                default:
                    throw new ArgumentException("No controller could be found using the name: " + nameOfObject);
            }


            try
            {
                result = (T)access;
            }
            catch (Exception e)
            {
                string s = e.StackTrace;
                throw new InvalidCastException("Could not cast " + result.GetType() + " to " + access.GetType());
            }

            return result;
        }
    }
}
