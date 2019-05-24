using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTL.View.Models;

namespace GTL.View.Controllers
{
    public class CatalogueController : Controller
    {
        // GET: Catalogue
        public ActionResult Index()
        {
            BookList booklist = new BookList();
            booklist.LoanableBooks.Add(new CatalogueModel() {ID = 1, DateCreated = "2/2/1990", Edition = 1, ISBN = 1234, isLoanable = true, Language = "Danish", PublicationYear = "2/2/1990", Publisher = "Mister Weber", Subject = "Philosophy", TitleName = "God is Dead", Type = " Book"});

            return View("Catalogue",booklist);


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
        public ActionResult Create(FormCollection collection)
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
