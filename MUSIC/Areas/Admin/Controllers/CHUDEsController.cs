using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MUSIC.Models;
using PagedList;

namespace MUSIC.Areas.Admin.Controllers
{
    public class CHUDEsController : Controller
    {
        private DBcontent db = new DBcontent();

        // GET: Admin/CHUDEs
        public ActionResult Index(int? page)
        {
            int PageSize = 10;
            int PageNum = (page ?? 1);
            var cHUDEs = db.CHUDEs.ToList();
            return View(cHUDEs.ToPagedList(PageNum, PageSize));
        }

        // GET: Admin/CHUDEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUDE cHUDE = db.CHUDEs.Find(id);
            if (cHUDE == null)
            {
                return HttpNotFound();
            }
            return View(cHUDE);
        }

        // GET: Admin/CHUDEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CHUDEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CHUDE cHUDE)
        {
            try
            {
                if (cHUDE.ImgUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(cHUDE.ImgUpload.FileName);
                    string extension = Path.GetExtension(cHUDE.ImgUpload.FileName);
                    fileName =  fileName + extension ;
                    cHUDE.hinhchude = "/images/chude/"+ fileName;
                    cHUDE.ImgUpload.SaveAs(Path.Combine(Server.MapPath("~/images/chude/"), fileName));
                }
                db.CHUDEs.Add(cHUDE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            
        }

        // GET: Admin/CHUDEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUDE cHUDE = db.CHUDEs.Find(id);
            if (cHUDE == null)
            {
                return HttpNotFound();
            }
            return View(cHUDE);
        }

        // POST: Admin/CHUDEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CHUDE cHUDE)
        {
            if (cHUDE.ImgUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(cHUDE.ImgUpload.FileName);
                string extension = Path.GetExtension(cHUDE.ImgUpload.FileName);
                fileName = fileName + extension ;
                cHUDE.hinhchude = "/images/chude/"+ fileName;
                cHUDE.ImgUpload.SaveAs(Path.Combine(Server.MapPath("~/images/chude/"), fileName));
            }
            db.Entry(cHUDE).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/CHUDEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUDE cHUDE = db.CHUDEs.Find(id);
            if (cHUDE == null)
            {
                return HttpNotFound();
            }
            return View(cHUDE);
        }

        // POST: Admin/CHUDEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHUDE cHUDE = db.CHUDEs.Find(id);
            db.CHUDEs.Remove(cHUDE);
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
