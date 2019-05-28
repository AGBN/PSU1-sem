using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTL.View.Models;
using GTL.Models;
using GTL.Factories;

namespace GTL.View.Controllers
{
    public class CatalogueController : Controller
    {
        // GET: Catalogue
        public ActionResult Index(string username = "")
        {
            BookList booklist = new BookList();

            ICollection<IModel> books = new List<IModel>();
            GTL.Controllers.IController controller = FactoryController.Instance.Create("title");


            books = controller.GetAll(10,0);

            foreach (Title item in books)
            {
                booklist.LoanableBooks.Add(new CatalogueModel()
                {
                    DateCreated = item.DateCreated.ToString(),
                    Edition = item.Edition,
                    ISBN = item.ISBN,
                    isLoanable = item.IsLoanable,
                    Language = item.Language,
                    PublicationYear = item.PublicationYear.ToString(),
                    Publisher = item.Publisher,
                    Subject = item.Subject,
                    TitleName = item.TitleName,
                    Type = item.Type
                });
            }

            ViewBag.Books = booklist;

            if (string.IsNullOrWhiteSpace(username) == false)
            {
                ViewBag.Username = username;
                ViewBag.LoggedIn = true;
            }

            return View("Catalogue", booklist);
        }

        // GET: Catalogue/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Catalogue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalogue/Create
        [HttpPost]
        public ActionResult Create(CatalogueModel catalogue)
        {
            try
            {
                
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Catalogue/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Catalogue/Edit/5
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

        // GET: Catalogue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Catalogue/Delete/5
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
