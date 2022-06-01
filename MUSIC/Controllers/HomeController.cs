using MUSIC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        
        [HttpGet]
        public ActionResult DetailsMusic(int id)
        {
            BAIHAT music = db.BAIHATs.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            /* db.BAIHATs.SqlQuery("update BAIHAT set luotxem = luotxem + 1 ").Where(n => n.idbaihat == id).ToList();*/
            music.luotxem += 1;
            db.Entry(music).State = EntityState.Modified;
            db.SaveChanges();
            return View(music);
        }
       
        
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchMUSIC) {
            return RedirectToAction("Search", "Home", new { key = searchMUSIC });
        }
        
    }
}