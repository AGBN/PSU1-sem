﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            throw new NotImplementedException();

        }

        public IModel Get(params object[] id)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params string[] id)
        {
            throw new NotImplementedException();
        }

        public IModel Insert(IModel model)
        {
            Book b, newB = (Book)model;

            newB.Title = null;

            using (var context = new GTL_Entities())
            {
                var query = (context.Books.SqlQuery("EXECUTE addBookCopy @tid, @bookstate, @available, @date", 
                    new SqlParameter("@tid", newB.TitleID),
                    new SqlParameter("@bookstate", newB.BookState),
                    new SqlParameter("@available", newB.Available),
                    new SqlParameter("@date", newB.DateAcquired)
                    )).FirstOrDefault();

                b = query;
            }

            return b;

        }
    }
}
