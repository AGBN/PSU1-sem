using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.DataAccess
{
    public class AddressDataAccess : IDataAccess
    {
        public object Action(string actionName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params int[] id)
        {
            throw new NotImplementedException();
        }

        public IModel Get(string id)
        {
            throw new NotImplementedException();
        }


        public IModel Insert(IModel model)
        {
            // TODO not implemented. Stub.

            return model;
        }
    }
}
