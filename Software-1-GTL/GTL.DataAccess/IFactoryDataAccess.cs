using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;

namespace GTL.Factories
{
    public interface IFactoryDataAccess
    {
        IDataAccess Create(string nameOfDataAccess);
    }
}
