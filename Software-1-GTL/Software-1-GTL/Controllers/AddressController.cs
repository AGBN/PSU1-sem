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

        public IModel Get(params string[] id)
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
            Address adr = null;

            // Check if objects exists, no need to create it another if it already exists.
            adr = (Address)DataAccess.Get(zip, city, streetName, streetNr, floorNr.ToString(), aptNr);

            // Get address from model factory
            if (adr == null)
            {
                adr = FactoryModels.CreateAddress(zip, city, streetName, streetNr, floorNr, aptNr, phoneNr);

                // Insert into database
                adr = (Address)DataAccess.Insert(adr);
            }

            // return created object
            return adr;
        }
    }
}
