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
            Address homeAdr = CreateAddress(1); //
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

        public Address CreateAddress(int i = 0) 
        {
            AddressController controller = (AddressController)FactoryController.Instance.Create("address"); //
            Address a;

            switch (i)
            {
                case 1:
                    a = controller.Create("9000", "Aalborg", "Blegkilde", "6", 1, "7"); 
                    break;

                default:
                    a = controller.Create("9000", "Aalborg", "Riishøjsvej", "53", 1); 
                    break;
            }

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
            MemberController mCtr = (MemberController)FactoryController.Instance.Create("member");

            Member m = (Member)mCtr.Get(123456);
            LibrarianRole lr = GetLibrarianRole();

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

            ICollection<Author> authors = CreateAuthor();

            Title t = controller.Create("Grp5 publishing", "Rise of Grp5", "C#", 1337, 5, 0916, "Testing purpose", "Prototype", "boring", true, authors);

            return t;
        }

        public ICollection<Author> CreateAuthor()
        {
            AuthorController controller = (AuthorController)FactoryController.Instance.Create("author");

            Author a1 = controller.Create("James", "Rickon", "Henderson", "Best Dexcription ever", 1992, 2000);

            return new Author[] { a1 };
        }

        public LibrarianRole GetLibrarianRole()
        {
            LibrarianRoleController controller = (LibrarianRoleController)FactoryController.Instance.Create("librarianRole");

            LibrarianRole lr = (LibrarianRole)controller.Get("ChiefLibrarian");

            return lr;
        }
    }
}
