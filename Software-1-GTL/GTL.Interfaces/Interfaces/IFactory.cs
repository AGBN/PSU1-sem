using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GTL.Interfaces
{
    public interface IFactory
    {
        IController CreateController(string NameOfController);

        IDataAccess CreateDataAccess(string NameOfDataAcces);

        IModel CreateModelMember();

            // TODO check if used. Delete if not.
        IModelFactory CreateModelFactory();
    }
}
