using GTL.View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTL.Factories;
using GTL.Models;
using GTL.Controllers;

namespace GTL.View.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            LibrarianController controller = (LibrarianController)FactoryController.Instance.Create("Librarian");

            bool success;

            try
            {
                success = controller.Login(model.Username, model.Password);
            }
            catch (Exception)
            {
                success = false;
            }


            if (success)
            {
                return RedirectToAction("Index", "Catalogue", new { username = model.Username });
            }
            else
            {
                ViewBag.LoginSuccess = false;
                return View("Login");
            }

            
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
