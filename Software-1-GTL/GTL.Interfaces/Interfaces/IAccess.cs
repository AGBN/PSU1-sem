using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Interfaces
{
    public interface IAccess
    {
        object Get(int id);
        void Create<T>(T item);
    }
}
