using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.Interfaces;
using GTL.Factories;

namespace GTL.Controllers
{
    public class MemberController : IController
    {

        public object Get(int id)
        {
            Member m = null ;


            IAccess db = new FactoryAccess().Create<IAccess>("Member");

            m = (Member)db.Get(id);

            return m;
        }

        public object Get(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<object> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
