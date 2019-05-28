using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTL.View.Models;
using GTL.Controllers;
using GTL.Factories;
using GTL.Models;

namespace GTL.View.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        public ActionResult Index(BookList list = null)
        {
            LoanModel lm = new LoanModel();

            if (list != null && list.LoanableBooks.Count > 0)
            {
                lm.ISBN = list.LoanableBooks[0].ISBN;
                lm.TitleName = list.LoanableBooks[0].TitleName;

                lm.LoanDate = DateTime.Now;
                return View("Loan", lm);
            }

            return View("Loan");
        }




        // GET: Loan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Loan/Create
        public ActionResult Create(LoanModel lm)
        {
            GTL.Controllers.LoanController lCtr = (GTL.Controllers.LoanController)FactoryController.Instance.Create("Loan");
            GTL.Controllers.MemberController mCtr = (GTL.Controllers.MemberController)FactoryController.Instance.Create("member");
            GTL.Controllers.LibrarianController libCtr = (GTL.Controllers.LibrarianController)FactoryController.Instance.Create("Librarian");
            GTL.Controllers.TitleController tCtr = (GTL.Controllers.TitleController)FactoryController.Instance.Create("Title");
            GTL.Controllers.BookController bCtr = (GTL.Controllers.BookController)FactoryController.Instance.Create("Book");


            Member m = (Member)mCtr.Get(lm.memberSSN);
            Librarian lib = (Librarian)libCtr.Get(2020002);

            Title t = (Title)tCtr.Get(lm.ISBN);
            Book b = (Book)bCtr.Get(t.ID);


            lCtr.Create(m, lib, new Book[] { b });


            return RedirectToAction("Index", "Home");
        }

        // GET: Loan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Loan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Loan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Loan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
