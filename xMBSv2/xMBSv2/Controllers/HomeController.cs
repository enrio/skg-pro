using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace xMBSv2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var db = new Models.Entities.ZContext();

            var a = db.Users.ToList();
            var b = db.Roles.ToList();

            ViewBag.a = a;
            ViewBag.b = b;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}