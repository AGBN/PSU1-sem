using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.DataAccess;

namespace GTL.Controllers
{
    public class BookController : IController
    {
        public IDataAccess DataAccess { get; }

        public BookController(IDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }

        public IModel Get(params int[] id)
        {
            Book b = null;

            b = (Book)DataAccess.Get(id);

            return b;
        }

        public IModel Get(params string[] id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }

        public Book Create(Title bookTitle, string bookState = "New")
        {
            // Instantiate variables
            DateTime dateCreated = DateTime.UtcNow;

            // Check if objects exists and requirements have been met.

            // Get object from model factory
            Book b = FactoryModels.CreateBook(bookTitle, dateCreated, bookState);

            // Create additional objects if needed


            // Assign additional variables if needed
            b.Available = true;

            // Insert into database
            b = (Book)DataAccess.Insert(b);

            // return created object
            return b;
        }

        public bool IsAllAvailable(ICollection<Book> books)
        {
            throw new NotImplementedException();
        }
    }
}
