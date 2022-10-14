using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MUSIC.Models;
using MUSIC.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void DangNhapThanhCong()
        {
            FormCollection c = new FormCollection();
            c.Add("TenDN", "baitaptest");
            c.Add("MatKhau", "test@123");

            NguoiDungController user = new NguoiDungController();
           

            ViewResult obj = (ViewResult)user.DangNhap(c);
            Assert.AreEqual("Index", obj.ViewName);
        }


        /*[TestMethod()]
        public void DangNhapThanhCong()
        {
            NguoiDungController user = new NguoiDungController();

            ViewResult obj = (ViewResult)user.DangNhap("tan123", "tan123");
            Assert.AreEqual("Index", obj.ViewName);
        }
        [TestMethod()]
        public void DangNhapTKnull()
        {
            NguoiDungController user = new NguoiDungController();

            ViewResult obj = (ViewResult)user.DangNhap(null, "tan123");
            Assert.AreEqual("Phải nhập tên đăng nhập", obj.ViewName);               
        }
        [TestMethod()]
        public void DangNhapMKnull()
        {
            NguoiDungController user = new NguoiDungController();

            ViewResult obj = (ViewResult)user.DangNhap("tan123",null);
            Assert.AreEqual("Cần nhập mật khẩu", obj.ViewName);
        }
        [TestMethod()]
        public void DangNhapFail()
        {
            NguoiDungController user = new NguoiDungController();

            ViewResult obj = (ViewResult)user.DangNhap("tan1234343", "ahihi");
            Assert.AreEqual("Tài khoản hoặc mật khẩu không chính xác", obj.ViewName);
        }
        [TestMethod()]
        public void DangNhapnull()
        {
            NguoiDungController user = new NguoiDungController();

            ViewResult obj = (ViewResult)user.DangNhap(null, null);
            Assert.AreEqual("Tài khoản hoặc mật khẩu không chính xác", obj.ViewName);
        }*/


    }
}
