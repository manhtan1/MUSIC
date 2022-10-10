using MUSIC.Common;
using MUSIC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MUSIC.Controllers
{
    public class NguoiDungController : Controller
    {
        DBcontent db = new DBcontent();
        // GET: NguoiDung
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult dangky(FormCollection collection, THANHVIEN kh)
        {
            var hoten = collection["Hoten"];
            var taikhoan = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            var email = collection["Email"];
            var nhaplaimatkhau = collection["NhapLaiMatKhau"];
            var diachi = collection["DiaChi"];
            var dienthoai = collection["DienThoai"];
            //var mk = collection["matkhau"];
            
                if ((String.IsNullOrEmpty(hoten)))
                {
                    ViewData["Loi1"] = "Bạn chưa nhập Họ tên!!";
                }
                else if (String.IsNullOrEmpty(taikhoan))
                {
                    ViewData["Loi2"] = "Bạn chưa nhập Tài khoản!!";
                }
                else if (String.IsNullOrEmpty(matkhau))
                {
                    ViewData["Loi3"] = "Bạn chưa cài mật khẩu !!";
                }
                else if (String.IsNullOrEmpty(email))
                {
                    ViewData["Loi5"] = "Bạn để trống email bạn đang dùng !!";
                }
                else if (String.IsNullOrEmpty(nhaplaimatkhau))
                {
                    if (email != nhaplaimatkhau)
                    {
                        ViewData["Loi8"] = "Mật khẩu nhập lại không trùng với mật khẩu !!";
                    }
                    ViewData["Loi4"] = "Bạn phải nhập lại mật khẩu!!";
                }
                else if (String.IsNullOrEmpty(dienthoai))
                {
                    ViewData["Loi6"] = "Bạn để trống số điện thoại của bạn !!";
                }
                else if (String.IsNullOrEmpty(diachi))
                {
                    ViewData["Loi7"] = "Bạn để trống địa chỉ bạn đang ở !!";
                }
                
            else
                {
                kh.HoTen = hoten;
                kh.TenDN = taikhoan;
                kh.MatKhau = matkhau;
                kh.Email = email;
                kh.DienThoai = diachi;
                kh.DiaChi = diachi;
                kh.NgayDangKy= DateTime.Now; 
                db.THANHVIENs.Add(kh);
                    db.SaveChanges();
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assetss/Customer/template/Gmail.html"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                
                    content = content.Replace("{{tk}}", kh.TenDN);
                    content = content.Replace("{{hoten}}", kh.HoTen);
                    content = content.Replace("{{email}}", kh.Email);


                new MailHelper().SendMail(kh.Email, "Đăng ký Tài khoản thành công!", content);
                    new MailHelper().SendMail(toEmail, "Đăng ký Tài khoản thành công!", content);

                    return RedirectToAction("DangNhap");
                }
            return this.DangKy();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(FormCollection ahihi)
        {
            var tendn = ahihi["TenDN"];
            var mk = ahihi["MatKhau"];
            if (string.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (string.IsNullOrEmpty(mk))
            {
                ViewData["Loi2"] = "Cần nhập mật khẩu";
            }
            else
            {
                THANHVIEN kh = db.THANHVIENs.SingleOrDefault(n => (n.TenDN == tendn && n.MatKhau == mk) || (n.Email == tendn && n.MatKhau == mk));
                if (kh != null)
                {
                    ViewBag.ThongBao = "Đăng nhập thành công";
                    Session["TaiKhoan"] = kh;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không chính xác"; ;
                }
            }
            return View();
        }
        public ActionResult Dangxuat()
        {
            THANHVIEN kh = (THANHVIEN)Session["TaiKhoan"];
            if (Session["TaiKhoan"] != null)
            {
                Session["TaiKhoan"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
        }
        public ActionResult Quenmk()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Quenmk(FormCollection collection)
        {
            var Email = collection["QuenMail"];
            string password = Membership.GeneratePassword(12, 1);
            THANHVIEN tHANHVIEN = db.THANHVIENs.SingleOrDefault(n => n.Email == Email);
            tHANHVIEN.MatKhau = password;
            db.SaveChanges();
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Assetss/Customer/template/Quenmk.html"));
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

            content = content.Replace("{{tk}}", tHANHVIEN.TenDN);

            content = content.Replace("{{pass}}", password);


            new MailHelper().SendMail(Email, "Lấy lại mật khẩu thành công!", content);
            new MailHelper().SendMail(toEmail, "Lấy lại mật khẩu thành công!", content);
            return RedirectToAction("/Dangnhap");
        }
        public ActionResult sussess()
        {
             return View();
        }

        public ActionResult Cmt(int idbaihat, FormCollection collection)
        {
            var cmt = collection["cmt"];
            THANHVIEN kh = (THANHVIEN)Session["TaiKhoan"];
            List<BAIHAT> music = new List<BAIHAT>();
            BAIHAT ms = music.SingleOrDefault(n => n.idbaihat == idbaihat);

           

            if (string.IsNullOrEmpty(cmt))
            {
                ViewData["Loi"] = "Bạn chưa nhập Comment";
            }
            Comment cm = new Comment();

                cm.idbaihat = idbaihat;
                cm.TenDN = kh.TenDN;
                cm.comment1 = cmt;
                cm.ngaycmt = DateTime.Now;
                db.Comments.Add(cm);
                db.SaveChanges();
                //return RedirectToAction("DetailsMusic", "Home", idbaihat);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Like(int idbaihat)
        {
            THANHVIEN kh = (THANHVIEN)Session["TaiKhoan"];
            CT_luotthich like = new CT_luotthich();
            BAIHAT music = db.BAIHATs.Find(idbaihat);
            
            if (like.thich = true)
            {
                music.luotthich += 1;
                db.Entry(music).State = EntityState.Modified;
                db.SaveChanges();
              /*  db.BAIHATs.SqlQuery("update BAIHAT set luotthich = luotthich + 1 where idbaihat like " + idbaihat );*/
            }
            like.TenDN = kh.TenDN;
            like.idbaihat = idbaihat;
            like.thich = true;

            db.CT_luotthich.Add(like);
            db.SaveChanges();

            ///Home/DetailsMusic/"+ idbaihat
            return RedirectToAction("Index","Home");

        }
        public ActionResult listlikeuser()
        {
            THANHVIEN kh = (THANHVIEN)Session["TaiKhoan"];
            return View(db.CT_luotthich.Where(n => n.TenDN == kh.TenDN).ToList());
        }
        public ActionResult ThongtinUser()
        {
            THANHVIEN kh = (THANHVIEN)Session["TaiKhoan"];

            return View(kh);
        }
        public ActionResult Doimk()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Doimk(FormCollection collection)
        {
            THANHVIEN kh = (THANHVIEN)Session["TaiKhoan"];
            var qmk = db.THANHVIENs.SingleOrDefault(n => n.TenDN == kh.TenDN);
            
            var mkcu = collection["mkcu"];
            var mkmoi = collection["Mknew"];
            if (kh.MatKhau==mkcu)
            {
                qmk.MatKhau = mkmoi;
                db.SaveChanges();
                Session["TaiKhoan"] = null;
                return RedirectToAction("Dangnhap", "Nguoidung");
            }
            else
            {
                ViewBag.ThongBao = "Mật khẩu không chính xác"; 
            }
            return View();
        }
        public ActionResult EditUser(string id)
        {
            THANHVIEN kh = (THANHVIEN)Session["TaiKhoan"];
            return View(kh);
            
        }
        [HttpPost]
        public ActionResult EditUser(THANHVIEN tHANHVIEN)
        {
            THANHVIEN kh = (THANHVIEN)Session["TaiKhoan"];

            
            if (ModelState.IsValid)
            {
                db.Entry(tHANHVIEN).State = EntityState.Modified;
                tHANHVIEN.MatKhau = kh.MatKhau;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("ThongtinUser", "Nguoidung");
        }
    }
}