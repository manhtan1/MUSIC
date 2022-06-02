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
            return View(new THELOAI { });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(THELOAI tHELOAI)
        {
            Random rnd = new Random();
            int idtl = rnd.Next(1,300);
            if (string.IsNullOrEmpty(tHELOAI.tentheloai) == true)
            {
                ModelState.AddModelError("", "Tên thể loại không được null");
                return View(tHELOAI);
            }
            if (tHELOAI.ImgTheLoai != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(tHELOAI.ImgTheLoai.FileName);
                string extension = Path.GetExtension(tHELOAI.ImgTheLoai.FileName);
                fileName = fileName + extension;
                tHELOAI.hinhtheloai = "/images/theloainhac/" + fileName;
                tHELOAI.ImgTheLoai.SaveAs(Path.Combine(Server.MapPath("~/images/theloainhac/"), fileName));
            }
                if (idtl == tHELOAI.idtheloai)
                {
                    idtl = rnd.Next();
                    idtl= tHELOAI.idtheloai ;
                db.THELOAIs.Add(tHELOAI);
                
            }
            db.SaveChanges();
            return RedirectToAction("Index");
            /* if (tHELOAI.idtheloai > 0)
             {
                 return RedirectToAction("Index");
             }
             else
             {
                 ModelState.AddModelError("", "Không thể lưu vào cơ sở dữ liệu");
                 return View(tHELOAI);
             }*/


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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( THELOAI tHELOAI)
        {
            var updatetl = db.THELOAIs.Find(tHELOAI.idtheloai);
            
            if (tHELOAI.ImgTheLoai != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(tHELOAI.ImgTheLoai.FileName);
                string extension = Path.GetExtension(tHELOAI.ImgTheLoai.FileName);
                fileName = fileName + extension;
                tHELOAI.hinhtheloai = "/images/theloainhac/" + fileName;
                tHELOAI.ImgTheLoai.SaveAs(Path.Combine(Server.MapPath("~/images/theloainhac/"), fileName));
                
            }
            updatetl.idchude = tHELOAI.idchude;
            updatetl.tentheloai = tHELOAI.tentheloai;
            updatetl.hinhtheloai = tHELOAI.hinhtheloai;
            db.Entry(updatetl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            
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
