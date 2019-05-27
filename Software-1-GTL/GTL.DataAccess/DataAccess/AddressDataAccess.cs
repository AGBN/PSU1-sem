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

        public IModel Get(params string[] id)
        {
            Address adr = null;

            int floorNr = int.Parse(id[4]);

            using (var context = new GTL_Entities())
            {
                var query = context.Addresses.Find(id[0], id[1], id[2], id[3], floorNr, id[5]);

                adr = query;
            }

            return adr;
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }

        public IModel Insert(IModel model)
        {
            Address adr;

            using (var context = new GTL_Entities())
            {
                adr = context.Addresses.Add((Address)model);

                context.SaveChanges();
            }

            return model;
        }
    }
}
