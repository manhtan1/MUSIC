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
    public class PLAYLISTsController : Controller
    {
        private DBcontent db = new DBcontent();

        // GET: Admin/PLAYLISTs
        public ActionResult Index(int? page)
        {
            int PageSize = 10;
            int PageNum = (page ?? 1);
            var pLAYLISTs = db.PLAYLISTs.ToList();
            return View(pLAYLISTs.ToPagedList(PageNum, PageSize));
        }

        // GET: Admin/PLAYLISTs/Details/5
        public ActionResult Details(int? id)
        {
            var baihat = db.PLAYLISTs.Find(id).BAIHATs;
            Session["baihat"] = baihat;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLAYLIST pLAYLIST = db.PLAYLISTs.Find(id);
            if (pLAYLIST == null)
            {
                return HttpNotFound();
            }
            return View(pLAYLIST);
        }

        // GET: Admin/PLAYLISTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PLAYLISTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PLAYLIST pLAYLIST)
        {
            
                try
                {
                    if (pLAYLIST.ImgPlaylist != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(pLAYLIST.ImgPlaylist.FileName);
                        string extension = Path.GetExtension(pLAYLIST.ImgPlaylist.FileName);
                        fileName = fileName + extension;
                         pLAYLIST.hinhnen = "/images/chude/" + fileName;
                    pLAYLIST.hinhicon = "/images/chude/" + fileName;
                    pLAYLIST.ImgPlaylist.SaveAs(Path.Combine(Server.MapPath("~/images/chude/"), fileName));
                    }
                    db.PLAYLISTs.Add(pLAYLIST);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
           
        }

        // GET: Admin/PLAYLISTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLAYLIST pLAYLIST = db.PLAYLISTs.Find(id);
            if (pLAYLIST == null)
            {
                return HttpNotFound();
            }
            return View(pLAYLIST);
        }

        // POST: Admin/PLAYLISTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( PLAYLIST pLAYLIST)
        {
            
                if (pLAYLIST.ImgPlaylist != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pLAYLIST.ImgPlaylist.FileName);
                    string extension = Path.GetExtension(pLAYLIST.ImgPlaylist.FileName);
                    fileName = fileName + extension;
                     pLAYLIST.hinhnen = "/images/chude/" + fileName;
                    pLAYLIST.hinhicon = "/images/chude/" + fileName;
                    pLAYLIST.ImgPlaylist.SaveAs(Path.Combine(Server.MapPath("~/images/chude/"), fileName));
                }
                db.Entry(pLAYLIST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }

        // GET: Admin/PLAYLISTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLAYLIST pLAYLIST = db.PLAYLISTs.Find(id);
            if (pLAYLIST == null)
            {
                return HttpNotFound();
            }
            return View(pLAYLIST);
        }

        // POST: Admin/PLAYLISTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PLAYLIST pLAYLIST = db.PLAYLISTs.Find(id);
            db.PLAYLISTs.Remove(pLAYLIST);
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
