using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTL.View.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            new GTL.Controllers.MemberController().Get<GTL.Models.Member>(1);
            new GTL.Controllers.MemberController().Get<GTL.Models.Librarian>(1);
            new GTL.Controllers.MemberController().Get<GTL.Models.Book>(1);

            return View();
        }
    }
}
