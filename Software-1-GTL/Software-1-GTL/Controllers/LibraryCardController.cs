using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.DataAccess;
using GTL.Factories;
using GTL.Models;

namespace GTL.Controllers
{
    public class LibraryCardController : IController
    {
        public IDataAccess DataAccess { get; }

        public LibraryCardController(IDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }

        public IModel Get(params int[] id)
        {
            LibraryCard lc;
            lc = (LibraryCard)DataAccess.Get(id);
            return lc;
        }

        public IModel Get(params string[] id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }

        public virtual LibraryCard Create(int cardNr, Member m)
        {
            // Instantiate varialbes
            DateTime dateCreated = DateTime.UtcNow;
            MemberTypeController mtCtr = (MemberTypeController)FactoryController.Instance.Create("membertype");
            MemberType mType = (MemberType)mtCtr.Get(m.Type);

            // Check if objects exists


            // Assign values to address
            LibraryCard lc = FactoryModels.CreateLibraryCard(cardNr, m, dateCreated);
            lc.ExpirationDate = dateCreated.AddDays(mType.LoanPeriod);

            // Insert into database
            lc = (LibraryCard)DataAccess.Insert(lc);

            // Create additional objects if needed


            // return created object
            return lc;
        }
    }
}
