﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.DataAccess
{
    public class MemberDataAccess : IDataAccess
    {
        public object Action(string actionName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IModel Get(params int[] id)
        {
            // TODO implement properly

            if (id[0] < 10)
                return null;

            Member m = new Member();
            m.FirstName = "svend";
            m.LastName = "Jokumsen";
            m.SSN = id[0];
            m.Type = "student";
            m.DateCreated = DateTime.UtcNow;

            return m;
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
