using MUSIC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MUSIC.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music
        DBcontent db = new DBcontent();
        private List<BAIHAT> baihat(int n)
        {
            return db.BAIHATs.OrderByDescending(a => a.idbaihat).Take(n).ToList();
        }
        public ActionResult BaiHat(int id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                id = 1;
                return View(db.BAIHATs.Where(n=>n.idbaihat==id));
            }
            return View(db.BAIHATs.Where(n => n.idbaihat == id));
            /*return View(db.BAIHATs.OrderByDescending(b => b.luotxem).ToList());*/
        }
        public ActionResult TopView()
        {
            var music = db.BAIHATs.OrderByDescending(b => b.luotxem).ToList();
            return View(music);
        }
        public ActionResult TopLike()
        {
            var music = db.BAIHATs.OrderByDescending(b => b.luotthich).ToList();
            return View(music);
        }
        
    }
}