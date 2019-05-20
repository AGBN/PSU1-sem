using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;
using GTL.Models;

namespace GTL.Controllers
{
    public class LibraryCardController : IController
    {
        public IDataAccess DataAccess { get; }

        public LibraryCardController(IDataAccess dataAccess)
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

        public LibraryCard Create()
        {
            // TODO implement properly using the steps below.

            LibraryCard libC = new LibraryCard();
            libC.CardNr = 123;

            libC = (LibraryCard)DataAccess.Insert(libC);

            return libC;

            // Instantiate varialbes


            // Check if objects exists


            // Assign values to address


            // Insert into database


            // Create additional objects if needed


            // return created object
        }
    }
}
