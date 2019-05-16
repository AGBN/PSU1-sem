using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DataAccess
{
    public interface IAccess
    {
        object Get(int id);
    }
}
