using MUSIC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MUSIC.Controllers
{
    public class HomeController : Controller
    {
        private DBcontent db = new DBcontent();
        public ActionResult Index()
        {

            return View(db.BAIHATs.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}