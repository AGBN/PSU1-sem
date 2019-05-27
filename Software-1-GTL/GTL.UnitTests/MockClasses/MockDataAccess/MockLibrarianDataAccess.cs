using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;
using GTL.Models;

namespace GTL.UnitTests.MockClasses.MockDataAccess
{
    public class MockLibrarianDataAccess : IDataAccess
    {
        private ICollection<Librarian> mockLibrarians;

        public MockLibrarianDataAccess()
        {
            mockLibrarians = new List<Librarian>();

            Librarian mockLib = new Librarian();
            mockLib.Username = "Magret45";
            mockLib.Password = "Horses4Lyfe";

            mockLibrarians.Add(mockLib);
        }

        public object Action(string actionName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params string[] id)
        {
            foreach (Librarian item in mockLibrarians)
            {
                if (id[0].Equals(item.Username))
                    return item;
            }

            return null;
        }

        public IModel Get(params int[] id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }

        public IModel Insert(IModel model)
        {
            throw new NotImplementedException();
        }
    }
}
