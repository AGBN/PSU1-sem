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
                var query = from lr in context.LibrarianRoles
                            where lr.RoleName == id[0]
                            select lr;

                libr = query.FirstOrDefault();
            }

            return libr;
        }

        public IModel Insert(IModel model)
        {
            throw new NotImplementedException();
        }
    }
}
