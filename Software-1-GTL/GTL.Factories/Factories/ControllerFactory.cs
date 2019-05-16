using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Controllers;

namespace GTL.Factories
{
    public class ControllerFactory
    {
        IController Create(string nameOfFactory)
        {
            IController controller;

            switch (nameOfFactory)
            {
                case "Loan":
                    controller = new LoanController();
                    break;
                    
                case "Book":
                    controller = new BookController();
                    break;

                case "Member":
                    controller = new MemberController();
                    break;



                default:
                    controller = null;
                    break;
            }


            return controller;
        } 
    }
}
