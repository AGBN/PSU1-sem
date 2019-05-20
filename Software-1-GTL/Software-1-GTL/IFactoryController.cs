﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;
using GTL.Controllers;

namespace GTL.Factories
{
    public interface IFactoryController
    {
        IController Create(string nameOfObject, IDataAccess dataAccess = null);

    }
}
