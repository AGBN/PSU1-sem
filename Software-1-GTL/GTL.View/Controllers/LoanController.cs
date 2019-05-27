using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTL.View.Models;

namespace GTL.View.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        public ActionResult Index()
        {
            
            return View("Loan");
        }

        // GET: Loan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Loan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loan/Create
        [HttpPost]
        public ActionResult Create(LoanModel loan)
        {
            try
            {
                //It should 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
