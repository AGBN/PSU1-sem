using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Models
{
    public static class FactoryModels
    {
        // TODO IMPORTANT Assign values to objects here instead of in the controller.

        public static Member CreateMember()
        {
            Member m = new Member();

            /*
            m.SSN;
            m.MobilePhoneNr;
            m.FirstName;
            m.LastName;
            m.CampusAddressID;
            m.HomeAddressID;
            m.IsActive;
            m.Type;
            m.DateCreated;
            m.Librarian;
            m.LibraryCards;
            m.Loans;
            m.MemberType;
            m.Notices;
            m.CampusAdress;
            m.HomeAddress;
            */


            return m;
        }

        public static Loan CreateLoan()
        {
            Loan l = new Loan();


            return l;
        }

        public static LoanBook CreateLoanBook()
        {
            LoanBook lb = new LoanBook();



            return lb;
        }




    }
}
