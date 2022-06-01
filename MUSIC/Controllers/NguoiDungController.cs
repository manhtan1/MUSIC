using MUSIC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                if (String.IsNullOrEmpty(taikhoan))
                {
                    ViewData["Loi2"] = "Bạn chưa nhập Tài khoản!!";
                }
                if (String.IsNullOrEmpty(matkhau))
                {
                    ViewData["Loi3"] = "Bạn chưa cài mật khẩu !!";
                }
                if (String.IsNullOrEmpty(email))
                {
                    ViewData["Loi5"] = "Bạn để trống email bạn đang dùng !!";
                }
                if (String.IsNullOrEmpty(nhaplaimatkhau))
                {
                    if (email != nhaplaimatkhau)
                    {
                        ViewData["Loi8"] = "Mật khẩu nhập lại không trùng với mật khẩu !!";
                    }
                    ViewData["Loi4"] = "Bạn phải nhập lại mật khẩu!!";
                }
                if (String.IsNullOrEmpty(dienthoai))
                {
                    ViewData["Loi6"] = "Bạn để trống số điện thoại của bạn !!";
                }
                if (String.IsNullOrEmpty(diachi))
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
                    ViewBag.ThongBao = "Đăng ký thành công";
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
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var mk = collection["MatKhau"];
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
                db.BAIHATs.SqlQuery("update BAIHAT set luotthich = luotthich + 1 where idbaihat like " + idbaihat );
            }
            like.TenDN = kh.TenDN;
            like.idbaihat = idbaihat;
            like.thich = true;

            db.CT_luotthich.Add(like);
            db.SaveChanges();

            ///Home/DetailsMusic/"+ idbaihat
            return RedirectToAction("Index","Home");

        }
        

    }
}