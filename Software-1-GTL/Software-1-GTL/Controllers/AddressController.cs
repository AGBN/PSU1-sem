using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.DataAccess;

namespace GTL.Controllers
{
    public class AddressController : IController
    {
        public IDataAccess DataAccess { get; }

        public AddressController(IDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }

        public IModel Get(params int[] id)
        {
            throw new NotImplementedException();
        }

        public IModel Get(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }

        public Address Create(string zip, string city, string streetName, string streetNr, int floorNr = -1, string aptNr = "", string phoneNr = "")
        {
            // Instantiate variables
            bool exists = false;
            Address adr = null;

            // Check if objects exists
                // TODO implement existance check.
                //adr = DataAccess.Get(/*??*/);

            // Get address from model factory
            if (adr == null)
                adr = FactoryModels.CreateAddress(zip, city, streetName, streetNr, floorNr, aptNr, phoneNr);


            // Insert into database
            adr = (Address)DataAccess.Insert(adr);

            // Create additional objects if needed


            // return created object
            return adr;
        }
    }
}
