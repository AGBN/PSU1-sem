using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;
using GTL.Models;


namespace GTL.Controllers
{
    public class AuthorController : IController
    {
        public IDataAccess DataAccess { get; }

        public AuthorController(IDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }

        public virtual IModel Get(params int[] id)
        {
            Author a = null;

            a = (Author)DataAccess.Get(id);

            return a;
        }

        public virtual IModel Get(params string[] id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }


        // return created object
        public Author Create(string firstName, string middleName, string lastName, string description, int birthYear, int deathYear)
        {
            // Instantiate variables
            Author a;

            DateTime dateCreated = DateTime.UtcNow;


            // Check if objects exists and requirements have been met.
            a = (Author)DataAccess.Get(firstName, middleName, lastName);

            // Get object from model factory
            if (a == null)
            {
                a = FactoryModels.CreateAuthor(firstName, middleName, lastName, description, birthYear, deathYear);

                // Insert into the database
                a = (Author)DataAccess.Insert(a);
            }

            // return created object
            return a;
        }
    }
}
