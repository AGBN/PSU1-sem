using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Interfaces
{
    public interface IDataAccess
    {
        IModel Get(int id);

        IModel Get(string id);

        void Insert(IModel model);
    }
}
