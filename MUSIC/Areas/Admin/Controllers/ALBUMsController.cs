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
    public class ALBUMsController : Controller
    {
        private DBcontent db = new DBcontent();

        // GET: Admin/ALBUMs
        public ActionResult Index()
        {
            return View(db.ALBUMs.ToList());
        }

        // GET: Admin/ALBUMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALBUM aLBUM = db.ALBUMs.Find(id);
            if (aLBUM == null)
            {
                return HttpNotFound();
            }
            return View(aLBUM);
        }

        // GET: Admin/ALBUMs/Create
        public ActionResult Create()
        {
            return View(new ALBUM { });
        }

        // POST: Admin/ALBUMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ALBUM aLBUM)
        {
            if (ModelState.IsValid)
            {
                db.ALBUMs.Add(aLBUM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (aLBUM.idalbum > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Không thể lưu vào cơ sở dữ liệu");
                return View(aLBUM);
            }
        }

        // GET: Admin/ALBUMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALBUM aLBUM = db.ALBUMs.Find(id);
            if (aLBUM == null)
            {
                return HttpNotFound();
            }
            return View(aLBUM);
        }

        // POST: Admin/ALBUMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idalbum,tenalbum,tencasialbum")] ALBUM aLBUM)
        {
            if (ModelState.IsValid)
            {
                var tl = db.ALBUMs.Find(aLBUM.idalbum);
                tl.tenalbum = aLBUM.tenalbum;
                tl.tencasialbum = aLBUM.tencasialbum;
                db.Entry(tl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aLBUM);
        }

        // GET: Admin/ALBUMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALBUM aLBUM = db.ALBUMs.Find(id);
            if (aLBUM == null)
            {
                return HttpNotFound();
            }
            return View(aLBUM);
        }

        // POST: Admin/ALBUMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALBUM aLBUM = db.ALBUMs.Find(id);
            db.ALBUMs.Remove(aLBUM);
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
