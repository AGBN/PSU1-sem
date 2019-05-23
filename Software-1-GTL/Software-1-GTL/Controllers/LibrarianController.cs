using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.DataAccess;
using GTL.Factories;
using GTL.Logic;

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

        public Librarian Create(Member m, string username, string password, LibrarianRole role)
        {
            // Instantiate variables
            LibraryCardController libCardCtr = (LibraryCardController)FactoryController.Instance.Create("libraryCard");

            DateTime dateCreated = DateTime.UtcNow;


            // Check if objects exists and requirements have been met.
            if (DataAccess.Get(m.SSN) != null)
                throw new Exception("Librarian already exists");


            // Get object from model factory
            Librarian lib = FactoryModels.CreateLibrarian(m, username, password, role, dateCreated);

            // Insert into the database
            lib = (Librarian)DataAccess.Insert(lib);

            // return created object
            return lib;
        }

        public bool Login(string username, string password)
        {
            bool success;

            Librarian lib = (Librarian)DataAccess.Get(username);
            LibrarianLogic libLogic = (LibrarianLogic)FactoryLogic.Instance.Create("Librarian");

            //success = (bool)DataAccess.Action("LogIn", username, password);

            success = libLogic.PasswordMatch(password, lib.Password);

            return success;
        }

    }
}
