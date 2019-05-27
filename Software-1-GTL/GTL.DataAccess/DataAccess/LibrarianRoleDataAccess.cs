using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.DataAccess
{
    public class LibrarianRoleDataAccess : IDataAccess
    {
        public object Action(string actionName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params int[] id)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params string[] id)
        {
            LibrarianRole libr;

            using (var context = new GTL_Entities())
            {
                var query = context.LibrarianRoles.Find(id);
                libr = query;
            }

            return libr;
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
