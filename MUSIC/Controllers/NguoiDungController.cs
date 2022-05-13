using MUSIC.Models;
using System;
using System.Collections.Generic;
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
                THANHVIEN kh = db.THANHVIENs.SingleOrDefault(n => n.TenDN == tendn || n.Email == tendn && n.MatKhau == mk);
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
    }
}