﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.DataAccess;

namespace GTL.Controllers
{
    public class BookController : IController
    {
        public IDataAccess DataAccess { get; }

        public BookController(IDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }

        public IModel Get(params int[] id)
        {
            IModel b = null;

            b = DataAccess.Get(id);

            return b;
        }

        public IModel Get(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }

        public Book Create()
        {
            // Instantiate varialbes


            // Check if objects exists


            // Assign values to address


            // Insert into database


            // Create additional objects if needed


            // return created object
            throw new NotImplementedException();
        }
    }
}
