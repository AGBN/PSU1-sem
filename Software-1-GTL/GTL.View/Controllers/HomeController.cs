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

        public ActionResult Test()
        {
            LoanController controller = (LoanController)FactoryController.Instance.Create("loan"); //

            Member m = CreateMember(); 
            Librarian lib = CreateLibrarian();
            ICollection<Book> books = CreateBooks();

            Loan l = controller.Create(m, lib, books);

            return View("Index");
        }

        public Member CreateMember(int i = 0)
        {
            MemberController controller = (MemberController)FactoryController.Instance.Create("member"); //

            Address campusAdr = CreateAddress(); //
            Address homeAdr = CreateAddress(); //
            MemberType mtype = GetMemberType(); 
            Member m;

            switch (i)
            {
                case 1:
                    m = controller.Create(123456, "jens", "Karls", "+45 123-456", campusAdr, homeAdr, mtype);
                    break;

                default:
                    m = controller.Create(123456, "jens", "Karls", "+45 123-456", campusAdr, homeAdr, mtype);
                    break;
            }
            

            return m;
        }

        /**/public Address CreateAddress() //
        {
            AddressController controller = (AddressController)FactoryController.Instance.Create("address"); //

            Address a = controller.Create("9000", "Aalborg", "Blegkilde", "6", 1, "7"); //

            return a;
        }

        public MemberType GetMemberType()
        {
            MemberTypeController controller = (MemberTypeController)FactoryController.Instance.Create("membertype"); //

            MemberType memberType = (MemberType)controller.Get("student"); 

            return memberType;

        }

        public Librarian CreateLibrarian()
        {
            LibrarianController controller = (LibrarianController)FactoryController.Instance.Create("librarian");

            Member m = CreateMember(1);
            LibrarianRole lr = CreateLibrarianRole();

            Librarian l = controller.Create(m, "BookMaster1337", "Glasses", lr);

            return l;
        }

        public ICollection<Book> CreateBooks()
        {
            BookController controller = (BookController)FactoryController.Instance.Create("book");

            Title t = CreateTitle();

            Book b1 = controller.Create(t);
            Book b2 = controller.Create(t, "Old");
            Book b3 = controller.Create(t, "Imaginary");

            return new Book[] {b1, b2, b3 };
        }

        public Title CreateTitle()
        {
            TitleController controller = (TitleController)FactoryController.Instance.Create("title");

            ICollection<Author> authors = CreateAuthor(/*TODO Test*/);

            Title t = controller.Create("Grp5 publishing", "Rise of Grp5", "C#", 1337, 5, 0916, "Testing purpose", "Prototype", "boring", true, authors);

            return t;
        }

        public ICollection<Author> CreateAuthor()
        {
            AuthorController controller = (AuthorController)FactoryController.Instance.Create("author");

            Author a1 = controller.Create(/*TODO Test*/);

            return new Author[] { a1 };
        }

        public LibrarianRole CreateLibrarianRole()
        {
            LibrarianRoleController controller = (LibrarianRoleController)FactoryController.Instance.Create("librarianRole");

            LibrarianRole lr = controller.Create();

            return lr;
        }
    }
}
