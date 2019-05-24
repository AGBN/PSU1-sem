using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;
using GTL.Models;
using GTL.Factories;

namespace GTL.Controllers
{
    public class TitleController : IController
    {
        public IDataAccess DataAccess { get; }

        public TitleController(IDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }

        public virtual IModel Get(params int[] id)
        {
            Title t = null;

            t = (Title)DataAccess.Get(id);

            return t;
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
        public Title Create(string publisher, string titleName, string language, int isbn, int edition, 
            int publicationYear, string description, string type, string subject, bool isLoanAble, ICollection<Author> authors)
        {
            DateTime dateCreated = DateTime.UtcNow;


            // Check if objects exists and requirements have been met.
            if (DataAccess.Get(isbn.ToString(), titleName) != null)
                throw new Exception("Title already exists");


            // Get object from model factory
            Title t = FactoryModels.CreateTitle(publisher, titleName, language, isbn, edition, publicationYear, description, type,subject, isLoanAble, authors, dateCreated);


            // Insert into the database
            t = (Title)DataAccess.Insert(t);

            // return created object
            return t;
        }
    }
}
