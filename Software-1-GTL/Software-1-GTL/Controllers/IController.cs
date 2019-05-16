using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Controllers
{
    public interface IController
    {
        object Get<T>(int id);
        object Get<T>(string id);
        ICollection<object> GetAll<T>(int amount, int offset);
        

    }
}
