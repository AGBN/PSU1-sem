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

        public IModel Get(params int[] id)
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

        public Member Create(int ssn, string firstName, string lastName, string mobileNr, Address campusAdr, Address homeAdr, string type = "student")
        {
            AddressController       adrCtr = (AddressController)FactoryController.Instance.Create("address");
            MemberTypeController    mTypeCtr = (MemberTypeController)FactoryController.Instance.Create("memberType");
            LibraryCardController   libCardCtr = (LibraryCardController)FactoryController.Instance.Create("libraryCard");

            MemberType mType = (MemberType)mTypeCtr.Get(type);

            // Check if objects exists.
            if (Get(ssn) != null)
                throw new Exception("Member already exists");

            if (mType == null)
                throw new Exception("MemberType Doesnt exist.");


            // Assign values to member
            Member m = FactoryModels.CreateMember();

            m.SSN = ssn;
            m.FirstName = firstName;
            m.LastName = lastName;
            m.MobilePhoneNr = mobileNr; // TODO needs PhoneNr Verification.

            m.CampusAdress = adrCtr.Create(campusAdr);
            m.CampusAddressID = m.CampusAdress.AddressID;

            m.HomeAddress = adrCtr.Create(homeAdr);
            m.HomeAddressID = m.HomeAddress.AddressID;

            m.MemberType = mType;

            m.IsActive = true;

            m.DateCreated = DateTime.UtcNow;

            // Insert into the database
            try
            {
                m = (Member)DataAccess.Insert(m);
            }
            catch (Exception e)
            {
                throw e;
            }

            // Create additional objects if needed
            libCardCtr.Create();

            // return created object
            return m;
        }

    }


    // Instantiate variables


    // Check if objects exists and requirements have been met.


    // Create objects


    // Insert into database


    // Create additional objects if needed


    // return created object
}
