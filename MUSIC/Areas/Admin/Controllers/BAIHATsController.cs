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
using MUSIC.Models;
using System.Configuration;
using MUSIC.Common;
using PagedList;
using PagedList.Mvc;
using System.Data.SqlClient;

namespace MUSIC.Areas.Admin.Controllers
{
    public class BAIHATsController : Controller
    {
        private DBcontent db = new DBcontent();


        // GET: Admin/BAIHATs
        public ActionResult Index(int ? page)
        {
            int PageSize = 10;
            int PageNum = (page ?? 1);
            var bAIHATs = db.BAIHATs.ToList();
            return View(bAIHATs.ToPagedList(PageNum, PageSize));
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
            if (postedFile!=null)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                if (postedFile.ContentLength < 104857600)
                {
                    if (bAIHAT.ImgBH != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(bAIHAT.ImgBH.FileName);
                        string extension = Path.GetExtension(bAIHAT.ImgBH.FileName);
                        filename = filename + extension;
                        bAIHAT.hinhbaihat = "/images/nhacsi/" + filename;
                        bAIHAT.ImgBH.SaveAs(Path.Combine(Server.MapPath("~/images/nhacsi/"), filename));
                    }


                    PLAYLIST pLAYLIST = db.PLAYLISTs.Find(bAIHAT.idplaylist);
                    bAIHAT.casi = pLAYLIST.ten;



                    postedFile.SaveAs(Server.MapPath("/music/"+ fileName));
                    string mainconn = ConfigurationManager.ConnectionStrings["DBcontent"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(mainconn);
                    string sqlquery = "insert into [dbo].[BAIHAT] values (@idtheloai,@idalbum,@idplaylist,@tenbaihat,@hinhbaihat,@casi,@linkbaihat,@lyrics,@luotxem,@luotthich)";
                    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                    sqlconn.Open();
                    /*sqlcomm.Parameters.AddWithValue("@idbaihat", bAIHAT.idbaihat);*/
                    sqlcomm.Parameters.AddWithValue("@idtheloai", bAIHAT.idtheloai);
                    sqlcomm.Parameters.AddWithValue("@idalbum", bAIHAT.idalbum);
                    sqlcomm.Parameters.AddWithValue("@idplaylist", bAIHAT.idplaylist);
                    sqlcomm.Parameters.AddWithValue("@tenbaihat", bAIHAT.tenbaihat);
                    sqlcomm.Parameters.AddWithValue("@hinhbaihat", bAIHAT.hinhbaihat);
                    sqlcomm.Parameters.AddWithValue("@casi", bAIHAT.casi);
                    sqlcomm.Parameters.AddWithValue("@linkbaihat", "/music/" + fileName);
                    sqlcomm.Parameters.AddWithValue("@lyrics", bAIHAT.lyrics);
                    sqlcomm.Parameters.AddWithValue("@luotxem", 0);
                    sqlcomm.Parameters.AddWithValue("@luotthich",  0);

                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();
                    ViewData["Message"] = "Record Saved Successfully!";
                }
            }



            string content = System.IO.File.ReadAllText(Server.MapPath("~/Assetss/Customer/template/newMusic.html"));
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
            foreach (var i in db.THANHVIENs.ToList())
            {
                content = content.Replace("{{customerMusic}}", bAIHAT.tenbaihat);
                content = content.Replace("{{casi}}", bAIHAT.casi);

                new MailHelper().SendMail(i.Email, "Nhạc mới", content);
                new MailHelper().SendMail(toEmail, "Nhạc mới", content);
            }

            return RedirectToAction("Index");

        }
     
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
        public ActionResult Edit(BAIHAT bAIHAT, HttpPostedFileBase postedFile)
        {
            if (postedFile != null)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                if (postedFile.ContentLength < 104857600)
                {
                    if (bAIHAT.ImgBH != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(bAIHAT.ImgBH.FileName);
                        string extension = Path.GetExtension(bAIHAT.ImgBH.FileName);
                        fileName = fileName + extension;
                        bAIHAT.hinhbaihat = "/images/nhacsi/" + filename;
                        bAIHAT.ImgBH.SaveAs(Path.Combine(Server.MapPath("~/images/nhacsi/"), fileName));
                    }


                    PLAYLIST pLAYLIST = db.PLAYLISTs.Find(bAIHAT.idplaylist);
                    bAIHAT.casi = pLAYLIST.ten;



                    postedFile.SaveAs(Server.MapPath("/music/" + fileName));
                    string mainconn = ConfigurationManager.ConnectionStrings["DBcontent"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(mainconn);
                    string sqlquery = "Update [dbo].[BAIHAT] set @idtheloai=" + bAIHAT.idtheloai + ", @idalbum=" + bAIHAT.idalbum + ",@idplaylist=" + bAIHAT.idplaylist + ",@tenbaihat=" + bAIHAT.tenbaihat + ",@hinhbaihat=" + bAIHAT.hinhbaihat + ",@casi=" + bAIHAT.casi + ",@linkbaihat=" + "/music/" + fileName + ",@lyrics=" + bAIHAT.lyrics + " where @idbaihat=" + bAIHAT.idbaihat + "";
                    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                    sqlconn.Open();
                   

                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();
                    ViewData["Message"] = "Record Saved Successfully!";
                }
            }
            db.Entry(bAIHAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
