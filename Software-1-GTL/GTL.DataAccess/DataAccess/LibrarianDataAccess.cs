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
            /*object result;

            switch (actionName.ToLower())
            {
                case "login":
                    result = Login((string)args[0], (string)args[1]);
                    break;

                default:
                    throw new ArgumentException("No action found with the name " + actionName);
            }

            return result;*/
            throw new NotImplementedException();
        }

        public IModel Get(params int[] id)
        {
            // TODO implement properly

            if (id[0] < 10)
                return null;

            Member m = new Member();
            m.FirstName = "Inge";
            m.LastName = "Larm-Bakke";
            m.SSN = id[0];
            m.Type = "faculty member";
            m.DateCreated = DateTime.UtcNow;

            Librarian Lib = new Librarian();
            Lib.SSN = m.SSN;
            Lib.Member = m;

            return Lib;
        }

        public IModel Get(string id)
        {
            Librarian lib;

            //Username is unique.

            using (var context = new GTL_Entities())
            {
                var query = from l in context.Librarians
                            where l.Username == id
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
