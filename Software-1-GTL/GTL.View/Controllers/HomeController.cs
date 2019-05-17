using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTL.Interfaces;
using GTL.Models;
using GTL.Factories;


namespace GTL.View.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //GTL.Interfaces.IController controller = (GTL.Interfaces.IController)Factory.GetFactory("Controller").Create("Member");

            Interfaces.IController controller = new FactoryController().Create<Interfaces.IController>("Member");

            Member m = (Member)controller.Get(1);

            return View();
        }
    }
}
