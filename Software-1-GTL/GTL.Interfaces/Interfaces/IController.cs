using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Interfaces
{
    public interface IController
    {
        object Get(int id);
        object Get(string id);
        ICollection<object> GetAll(int amount, int offset);
        

    }
}
