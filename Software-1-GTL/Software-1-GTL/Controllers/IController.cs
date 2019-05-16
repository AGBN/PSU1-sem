using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Controllers
{
    public interface IController
    {
        object Get(int id);
        object Get(string id);
        ICollection<object> GetAll(int amount, int offset);
        

    }
}
