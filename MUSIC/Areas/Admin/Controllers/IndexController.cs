using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MUSIC.Areas.Admin.Controllers
{
    public class IndexController : Controller
    {
        // GET: Admin/Index
        public ActionResult index()
        {
            return View();
        }
    }
}