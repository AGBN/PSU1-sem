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

            Member m = controller.Create(1, "jens", "Karls", "+45 123-456", null, null, null);


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

            Loan l = controller.Create(new Member() { SSN = 1 }, new Librarian() { SSN = 2 }, new Book[]{ new Book() { TitleID = 1, CopyNr = 10 }, new Book() { TitleID = 2, CopyNr = 20 }, new Book() { TitleID = 3, CopyNr = 30 } });


            List<string> text = new List<string>();

            text.Add(l.Member.SSN.ToString());
            text.Add(l.Librarian.SSN.ToString());

            foreach (var item in l.LoanBooks)
            {
                text.Add(item.BookID + " - " + item.CopyNr);
            }

            ViewBag.Text = text;

            return View("Index");
        }

        public ActionResult Title()
        {
            TitleController tCtr = (TitleController)FactoryController.Instance.Create("title");

            Title t = tCtr.Create("Best", "TitleHere!", "1337", 123, 1, 1234, "YEPYEPYEOP", "Book", "Random", true, new Author[] { new Author() });

            ViewBag.Text = new List<string>() { t.TitleName, t.ISBN +"", t.Publisher, t.Subject  };

            return View("Index");
        }

        public ActionResult Book()
        {
            BookController bCtr = (BookController)FactoryController.Instance.Create("book");

            Book b = bCtr.Create(new Title());

            ViewBag.Text = new List<string>() { };

            return View("Index");
        }
    }
}
