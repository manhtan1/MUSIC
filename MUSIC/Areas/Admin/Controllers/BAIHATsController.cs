using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using MUSIC.Models;

namespace MUSIC.Areas.Admin.Controllers
{
    public class BAIHATsController : Controller
    {
        private DBcontent db = new DBcontent();
        private IHostingEnvironment Environment;

        // GET: Admin/BAIHATs
        public ActionResult Index()
        {
            var bAIHATs = db.BAIHATs.Include(b => b.ALBUM).Include(b => b.PLAYLIST).Include(b => b.THELOAI);
            return View(bAIHATs.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAIHAT bAIHAT = db.BAIHATs.Find(id);
            if (bAIHAT == null)
            {
                return HttpNotFound();
            }
            return View(bAIHAT);
        }

        // GET: Admin/BAIHATs/Create
        public ActionResult Create()
        {
            ViewBag.idalbum = new SelectList(db.ALBUMs, "idalbum", "tenalbum");
            ViewBag.idplaylist = new SelectList(db.PLAYLISTs, "idplaylist", "ten");
            ViewBag.idtheloai = new SelectList(db.THELOAIs, "idtheloai", "tentheloai");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BAIHAT bAIHAT, HttpPostedFileBase postedFile)
        {
            if (bAIHAT.ImgBH != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(bAIHAT.ImgBH.FileName);
                string extension = Path.GetExtension(bAIHAT.ImgBH.FileName);
                fileName = fileName + extension;
                bAIHAT.hinhbaihat = "/images/theloainhac/" + fileName;
                bAIHAT.ImgBH.SaveAs(Path.Combine(Server.MapPath("~/images/nhacsi/"), fileName));
            }

            linknhac(postedFile);

             PLAYLIST pLAYLIST = db.PLAYLISTs.Find(bAIHAT.idplaylist);
            bAIHAT.casi = pLAYLIST.ten;
            bAIHAT.luotthich = 0;
            bAIHAT.luotxem = 0;
            db.BAIHATs.Add(bAIHAT);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public string linknhac(HttpPostedFileBase postedFile)
        {
            BAIHAT bAIHAT = new BAIHAT();
            
                string fileName = Path.GetFileNameWithoutExtension(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                fileName = fileName + extension;
                bAIHAT.linkbaihat =  fileName;
                postedFile.SaveAs(Path.Combine(Server.MapPath("~/music/"), fileName));
            return bAIHAT.linkbaihat;
        }

       

        // GET: Admin/BAIHATs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAIHAT bAIHAT = db.BAIHATs.Find(id);
            if (bAIHAT == null)
            {
                return HttpNotFound();
            }
            ViewBag.idalbum = new SelectList(db.ALBUMs, "idalbum", "tenalbum", bAIHAT.idalbum);
            ViewBag.idplaylist = new SelectList(db.PLAYLISTs, "idplaylist", "ten", bAIHAT.idplaylist);
            ViewBag.idtheloai = new SelectList(db.THELOAIs, "idtheloai", "tentheloai", bAIHAT.idtheloai);
            return View(bAIHAT);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idbaihat,idtheloai,idalbum,idplaylist,tenbaihat,hinhbaihat,casi,linkbaihat")] BAIHAT bAIHAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAIHAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idalbum = new SelectList(db.ALBUMs, "idalbum", "tenalbum", bAIHAT.idalbum);
            ViewBag.idplaylist = new SelectList(db.PLAYLISTs, "idplaylist", "ten", bAIHAT.idplaylist);
            ViewBag.idtheloai = new SelectList(db.THELOAIs, "idtheloai", "tentheloai", bAIHAT.idtheloai);
            return View(bAIHAT);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAIHAT bAIHAT = db.BAIHATs.Find(id);
            if (bAIHAT == null)
            {
                return HttpNotFound();
            }
            return View(bAIHAT);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BAIHAT bAIHAT = db.BAIHATs.Find(id);
            db.BAIHATs.Remove(bAIHAT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
