using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.DataAccess
{
    public class TitleDataAccess : IDataAccess
    {
        public object Action(string actionName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params int[] id)
        {
            int isbn = id[0];
            Title title;

            using (var context = new GTL_Entities())
            {
                var query = context.Titles.Where(t => t.ISBN == isbn).SingleOrDefault();

                title = query;
            }

            return title;
        }

        public IModel Get(params string[] id)
        {
            Title t;
            int isbn = int.Parse(id[0]);
            string name = id[1];


            using (var context = new GTL_Entities())
            {
                var query = context.Titles.Where(ti => ti.ISBN == isbn && ti.TitleName == name);
                t = query.FirstOrDefault();
            }

            return t;
        }

        public ICollection<IModel> GetAll(int amount = 10, int offset = 0)
        {
            List<IModel> titleList = new List<IModel>();

            using (var context = new GTL_Entities())
            {
                var query = context.Titles.OrderBy(t => t.ID).Skip(offset).Take(amount);

                titleList.AddRange(query);
            }

            return titleList;
        }

        public IModel Insert(IModel model)
        {
            Title t;

            using (var context = new GTL_Entities())
            {
                t = context.Titles.Add((Title)model);
                context.SaveChanges();
            }

            return t;
        }
    }
}
