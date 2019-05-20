using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTL.Models;
using GTL.Controllers;
using GTL.Factories;


namespace GTL.View.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Member()
        {
            MemberController controller = (MemberController)FactoryController.Instance.Create("member");

            Member m = controller.Create(1, "jens", "Karls", "+45 123-456", null, null);


            ViewBag.Text = new List<string>() { m.SSN.ToString(), m.FirstName, m.MobilePhoneNr };

            return View("Index");
        }

        public ActionResult Login()
        {
            List<string> text = new List<string>();
            bool success = false;

            LibrarianController libCtr = (LibrarianController)FactoryController.Instance.Create("librarian");

            success = libCtr.Login("user","pass");


            if (success)
                text.Add("Logged in");
            else
                text.Add("NOT Logged in");


            ViewBag.LoggedIn = true;
            ViewBag.Text = text;

            return View("Index");
        }

        public ActionResult Logout()
        {
            List<string> text = new List<string>();


           text.Add("NOT Logged in");


            ViewBag.LoggedIn = false;
            ViewBag.Text = text;

            return View("Index");
        }

        public ActionResult LoanItem()
        {
            LoanController controller = (LoanController)FactoryController.Instance.Create("loan");

            Loan l = controller.Create(10, 20, new int[] {1, 2, 3});


            List<string> text = new List<string>();

            text.Add(l.Member.FirstName);
            text.Add(l.Librarian.Member.FirstName);

            foreach (var item in l.LoanBooks)
            {
                text.Add(item.BookID + " - " + item.CopyNr);
            }

            ViewBag.Text = text;

            return View("Index");
        }
    }
}
