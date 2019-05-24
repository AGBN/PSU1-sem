using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;
using GTL.DataAccess;
using GTL.Factories;

namespace GTL.Controllers
{
    public class MemberController : IController
    {

        public IDataAccess DataAccess { get;}

        public MemberController(IDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }

        public virtual IModel Get(params int[] id)
        {
            IModel m = null ;

            m = DataAccess.Get(id);

            return m;
        }

        public virtual IModel Get(params string[] id)
        {
            throw new NotImplementedException();
        }

        public virtual ICollection<IModel> GetAll(int amount, int offset)
        {
            throw new NotImplementedException();
        }
        

        // return created object
        public Member Create(int ssn, string firstName, string lastName, string mobileNr, Address campusAdr, Address homeAdr, MemberType memberType)
        {
            // Instantiate variables
            LibraryCardController libCardCtr = (LibraryCardController)FactoryController.Instance.Create("libraryCard");

            Member m = null;
            DateTime dateCreated = DateTime.UtcNow;


            // Check if objects exists and requirements have been met.
            if (DataAccess.Get(ssn) != null)
                throw new Exception("Member already exists");


            // Get object from model factory
            m = FactoryModels.CreateMember(ssn, firstName, lastName, mobileNr, campusAdr, homeAdr, memberType, dateCreated);


            // Insert into the database
            m = (Member)DataAccess.Insert(m);

            // Create additional objects if needed
            LibraryCard libCard = libCardCtr.Create((ssn+dateCreated.Year), m);

            // Assign additional variables if needed
            m.LibraryCards.Add(libCard);
            m.IsActive = true;


            // return created object
            return m;
        }

        public bool CanLoan(Member member)
        {
            return (bool)DataAccess.Action("canloan", member);
        }
    }


    // Instantiate variables


    // Check if objects exists and requirements have been met.


    // Get object from model factory


    // Create additional objects if needed


    // Assign additional variables if needed


    // Insert into database


    // return created object
}
