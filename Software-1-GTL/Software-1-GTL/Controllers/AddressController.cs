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

        public Address Create(Address adr)
        {
            // TODO implement properly using the steps below.

            adr = new Address();
            adr.AddressID = 1;

            adr = (Address)DataAccess.Insert(adr);

            return adr;

            // Instantiate varialbes


            // Check if objects exists


            // Assign values to address


            // Insert into database


            // Create additional objects if needed


            // return created object
        }
    }
}
