using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.DataAccess;
using GTL.Factories;

namespace GTL.Controllers
{
    public class LibrarianController : IController
    {

        public IDataAccess DataAccess { get;}

        public LibrarianController(IDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }

        public IModel Get(params int[] id)
        {
            IModel m = null ;

            m = DataAccess.Get(id);

            return m;
        }

        public IModel Get(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }

        public Librarian Create()
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            bool success = false;

            // Security should be handled here.
            success = (bool)DataAccess.Action("LogIn", username, password);

            return success;
        }

    }
}
