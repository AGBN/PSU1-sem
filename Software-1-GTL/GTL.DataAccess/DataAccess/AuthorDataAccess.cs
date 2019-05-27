using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.DataAccess
{
    public class AuthorDataAccess : IDataAccess
    {
        public object Action(string actionName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params string[] id)
        {
            Author a = null;
            string firstName = id[0], middleName = id[1], lastName = id[2];
            

            using (var context = new GTL_Entities())
            {
                // This is flawed, but it will work in most uses.
                var query = context.Authors.Where(a => a.FirstName == firstName && a.MiddleName == middleName && a.LastName == lastName);

                a = query.FirstOrDefault();
            }

            return a;
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
            Author au;

            using (var context = new GTL_Entities())
            {
                au = context.Authors.Add((Author)model);

                context.SaveChanges();
            }

            return model;
        }
    }
}
