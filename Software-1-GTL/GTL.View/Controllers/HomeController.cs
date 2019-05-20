using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTL.Models;
using GTL.Controllers;


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
