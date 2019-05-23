using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.DataAccess;

namespace GTL.Controllers
{
    public class MemberTypeController : IController
    {
        public IDataAccess DataAccess { get; }

        public MemberTypeController(IDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }

        public IModel Get(params int[] id)
        {
            throw new NotImplementedException();
        }

        public virtual IModel Get(params string[] id)
        {
            return DataAccess.Get(id);
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
