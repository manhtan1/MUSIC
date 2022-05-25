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
    public class THELOAIsController : Controller
    {
        private DBcontent db = new DBcontent();

        // GET: Admin/THELOAIs
        public ActionResult Index()
        {
            var tHELOAIs = db.THELOAIs.Include(t => t.CHUDE);
            return View(tHELOAIs.ToList());
        }

        // GET: Admin/THELOAIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THELOAI tHELOAI = db.THELOAIs.Find(id);
            if (tHELOAI == null)
            {
                return HttpNotFound();
            }
            return View(tHELOAI);
        }

        // GET: Admin/THELOAIs/Create
        public ActionResult Create()
        {
            ViewBag.idchude = new SelectList(db.CHUDEs, "idchude", "tenchude");
            return View();
        }

        // POST: Admin/THELOAIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtheloai,idchude,tentheloai,hinhtheloai")] THELOAI tHELOAI)
        {
            if (ModelState.IsValid)
            {
                db.THELOAIs.Add(tHELOAI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idchude = new SelectList(db.CHUDEs, "idchude", "tenchude", tHELOAI.idchude);
            return View(tHELOAI);
        }

        // GET: Admin/THELOAIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THELOAI tHELOAI = db.THELOAIs.Find(id);
            if (tHELOAI == null)
            {
                return HttpNotFound();
            }
            ViewBag.idchude = new SelectList(db.CHUDEs, "idchude", "tenchude", tHELOAI.idchude);
            return View(tHELOAI);
        }

        // POST: Admin/THELOAIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtheloai,idchude,tentheloai,hinhtheloai")] THELOAI tHELOAI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHELOAI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idchude = new SelectList(db.CHUDEs, "idchude", "tenchude", tHELOAI.idchude);
            return View(tHELOAI);
        }

        // GET: Admin/THELOAIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THELOAI tHELOAI = db.THELOAIs.Find(id);
            if (tHELOAI == null)
            {
                return HttpNotFound();
            }
            return View(tHELOAI);
        }

        // POST: Admin/THELOAIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THELOAI tHELOAI = db.THELOAIs.Find(id);
            db.THELOAIs.Remove(tHELOAI);
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
