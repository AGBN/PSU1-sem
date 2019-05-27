using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.DataAccess
{
    public interface IDataAccess
    {
        IModel Get(params string[] id);

        IModel Get(params int[] id);

        ICollection<IModel> GetAll(int amount, int offset);


        IModel Insert(IModel model);

        object Action(string actionName, params object[] args);
    }
}
