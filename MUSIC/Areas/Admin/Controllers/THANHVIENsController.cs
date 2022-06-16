using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MUSIC.Models;
using PagedList;

namespace MUSIC.Areas.Admin.Controllers
{
    public class THANHVIENsController : Controller
    {
        private DBcontent db = new DBcontent();

        // GET: Admin/THANHVIENs
        public ActionResult Index(int? page)
        {
            int PageSize = 10;
            int PageNum = (page ?? 1);
            var tHANHVIENs = db.THANHVIENs.ToList();
            return View(tHANHVIENs.ToPagedList(PageNum, PageSize));
        }

        // GET: Admin/THANHVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANHVIEN tHANHVIEN = db.THANHVIENs.Find(id);
            if (tHANHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tHANHVIEN);
        }

        // GET: Admin/THANHVIENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/THANHVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenDN,HoTen,MatKhau,DienThoai,NgayDangKy,Email,DiaChi,GioiTinh,NgaySinh,CauHoiBaoMat,CauTraLoi")] THANHVIEN tHANHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.THANHVIENs.Add(tHANHVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHANHVIEN);
        }

        // GET: Admin/THANHVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANHVIEN tHANHVIEN = db.THANHVIENs.Find(id);
            if (tHANHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tHANHVIEN);
        }

        // POST: Admin/THANHVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenDN,HoTen,MatKhau,DienThoai,NgayDangKy,Email,DiaChi,GioiTinh,NgaySinh,CauHoiBaoMat,CauTraLoi")] THANHVIEN tHANHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHANHVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHANHVIEN);
        }

        // GET: Admin/THANHVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANHVIEN tHANHVIEN = db.THANHVIENs.Find(id);
            if (tHANHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tHANHVIEN);
        }

        // POST: Admin/THANHVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THANHVIEN tHANHVIEN = db.THANHVIENs.Find(id);
            db.THANHVIENs.Remove(tHANHVIEN);
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
