using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;
using GTL.Logic;

namespace GTL.Factories
{
    public interface IFactoryLogic
    {
        ILogic Create(string nameOfObject);

    }
}
