using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace GTL.Controllers
{
    public class MemberController : IController
    {
        public object Get(int id)
        {
            throw new NotImplementedException();
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
