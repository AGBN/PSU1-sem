using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;

namespace GTL.Controllers
{
    public interface IFactoryController
    {
        IController Create(string nameOfObject, IDataAccess dataAccess = null);

    }
}
