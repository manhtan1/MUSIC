using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MUSIC.Models;

namespace MUSIC.Controllers
{
    public class ListenedController : Controller
    {
        // GET: Listened
        DBcontent db = new DBcontent();

        public List<Listening> LayNhacVuaNghe()
        {
            List<Listening> listenings = Session["Listen"] as List<Listening>;
            if (listenings == null)
            {
                listenings = new List<Listening>();
                Session["Listen"] = listenings;
            }
            return listenings;
        }
       /* [HttpPost]*/
        public ActionResult ThemNhac(int id,string strURL)
        {
            List<Listening> listenings= LayNhacVuaNghe();
            Listening nhac = listenings.Find(n => n.idbaihat == id);
            if (nhac == null)
            {
                nhac = new Listening(id);
                listenings.Add(nhac);
                //return Redirect("~/Music/Baihat/"+id);
                return Redirect(strURL);

            }
            else
            {
                return RedirectToAction("~/Music/Baihat/", new { id } );
            }
        }
        public ActionResult ListNhac()
        {
            List<Listening> listenings = LayNhacVuaNghe();
            if (listenings.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(listenings);
        }
    }
}