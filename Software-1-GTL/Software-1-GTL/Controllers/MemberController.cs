using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.DataAccess;

namespace GTL.Controllers
{
    public class MemberController : IController
    {

        public IDataAccess DataAccess { get;}

        public MemberController(IDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }

        public IModel Get(int id)
        {
            IModel m = null ;

            m = DataAccess.Get(id);

            return m;
        }

        public IModel Get(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
            Member m = FactoryModels.CreateMember();

            DataAccess.Insert(m);
        }


        
    }
}
