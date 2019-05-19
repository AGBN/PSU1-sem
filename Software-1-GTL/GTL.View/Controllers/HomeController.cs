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

            return View();
        }

        public ActionResult Member()
        {
            /*Interfaces.IController controller = new FactoryController().Create<Interfaces.IController>("Member");


            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("SSN", 123);

            controller.Create(d);
            Member m = (Member)controller.Get(1);*/


           IMemberController controller = (IMemberController)new Factory().CreateController("member");

            controller.Create();

            Member m = (Member)controller.Get(132);

            ViewBag.Text = new List<string>() { "hej", "med", "dig" };

            return View("Index");
        }

        private void CreateMember()
        {
            
        }
    }
}
