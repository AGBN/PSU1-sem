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
            Librarian lib;

            using (var context = new GTL_Entities())
            {
                var query = context.Librarians.Find(id[0]);
                lib = query;
            }

            return lib;
        }

        public IModel Get(params string[] id)
        {
            Librarian lib;

            string username = id[0];

            //Username is unique.
            using (var context = new GTL_Entities())
            {
                var query = from l in context.Librarians
                            where l.Username == username
                            select l;

                lib = query.FirstOrDefault();
            }

            return lib;
        }
        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }
        public IModel Insert(IModel model)
        {
            Librarian l, newL = (Librarian)model;

            newL.Member = null;

            using (var context = new GTL_Entities())
            {
                l = context.Librarians.Add(newL);

                context.SaveChanges();
            }

            return l;

        }

    }
}
