using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Controllers
{
    public class BookController : IController
    {
        public object Get<T>(int id)
        {
            throw new NotImplementedException();
        }

        public object Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<object> GetAll<T>(int amount, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
