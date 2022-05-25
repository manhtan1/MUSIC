using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MUSIC.Models;

namespace MUSIC.Areas.Admin.Controllers
{
    public class BAIHATsController : Controller
    {
        private DBcontent db = new DBcontent();

        // GET: Admin/BAIHATs
        public ActionResult Index()
        {
            var bAIHATs = db.BAIHATs.Include(b => b.ALBUM).Include(b => b.PLAYLIST).Include(b => b.THELOAI);
            return View(bAIHATs.ToList());
        }

        // GET: Admin/BAIHATs/Details/5
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

        // POST: Admin/BAIHATs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idbaihat,idtheloai,idalbum,idplaylist,tenbaihat,hinhbaihat,casi,linkbaihat")] BAIHAT bAIHAT)
        {
            if (ModelState.IsValid)
            {
                db.BAIHATs.Add(bAIHAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idalbum = new SelectList(db.ALBUMs, "idalbum", "tenalbum", bAIHAT.idalbum);
            ViewBag.idplaylist = new SelectList(db.PLAYLISTs, "idplaylist", "ten", bAIHAT.idplaylist);
            ViewBag.idtheloai = new SelectList(db.THELOAIs, "idtheloai", "tentheloai", bAIHAT.idtheloai);
            return View(bAIHAT);
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

        // POST: Admin/BAIHATs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Admin/BAIHATs/Delete/5
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

        // POST: Admin/BAIHATs/Delete/5
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
