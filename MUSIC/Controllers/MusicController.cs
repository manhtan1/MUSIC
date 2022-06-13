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
            var lstNhac = (List<Listening>) Session["Listen"];
            if (lstNhac == null)
            {
                lstNhac = new List<Listening>();
                Session["Listen"] = lstNhac;
            }
            Listening nhac = lstNhac.Find(n => n.idbaihat == id);
            if (nhac == null)
            {
                nhac = new Listening(id);
                lstNhac.Add(nhac);
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
        [HttpPost]
        public ActionResult nextsong(int id)
        {
            id += 1;
            var songs = db.BAIHATs.ToList();
            if (id > songs.Count)
            {
                id = 1;
            }
            return RedirectToAction("Baihat/"+id);
        }
        
            [HttpPost]
        public ActionResult prevsong(int id)
        {
            id -= 1;
            var songs = db.BAIHATs.ToList();
            if (id <= 0)
            {
                id = songs.Count;
            }
            return RedirectToAction("Baihat/" + id);
        }
       

    }
}