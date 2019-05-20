using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.DataAccess
{
    public class BookDataAccess : IDataAccess
    {
        public object Action(string actionName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params int[] id)
        {
            // TODO implement properly
            Book b = new Book(); ;

            switch (id[0])
            {
                case 1:
                    b.TitleID = 1;
                    b.CopyNr = 1;
                    break;

                case 2:
                    b.TitleID = 2;
                    b.CopyNr = 2;
                    break;

                case 3:
                    b.TitleID = 3;
                    b.CopyNr = 3;
                    break;

                default:
                    break;
            }

            return b;
        }

        public IModel Get(string id)
        {
            throw new NotImplementedException();
        }

        public IModel Insert(IModel model)
        {
            // TODO not implemented. Stub.

            return model;
        }
    }
}
