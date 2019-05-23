using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.DataAccess
{
    public class LibrarianDataAccess : IDataAccess
    {
        public object Action(string actionName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params int[] id)
        {
            // TODO implement properly

            throw new NotImplementedException();

        }

        public IModel Get(params string[] id)
        {
            Librarian lib;

            //Username is unique.

            using (var context = new GTL_Entities())
            {
                var query = from l in context.Librarians
                            where l.Username == id[0]
                            select l;

                lib = query.First();
            }

            return lib;
        }

        public IModel Insert(IModel model)
        {
            // TODO not implemented. Stub.

            return model;
        }

        /*
        private bool Login(string user, string pass)
        {
            // TODO implement login properly
            bool success = false;

            success = true;

            return success;
        }*/
    }
}
