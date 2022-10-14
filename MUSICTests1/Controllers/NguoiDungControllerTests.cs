using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MUSIC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MUSIC.Controllers.Tests
{
    [TestClass()]
    public class NguoiDungControllerTests
    {
        [TestMethod()]
        public void DangNhapTest()
        {
            FormCollection c = new FormCollection();
            c.Add("TenDN", "baitaptest");
            c.Add("MatKhau", "test@123");
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            NguoiDungController user = new NguoiDungController();
            user.ControllerContext = context.Object;
            RedirectToRouteResult obj = (RedirectToRouteResult)user.DangNhap(c);
            Assert.AreEqual("Index", obj.RouteValues.Values.ElementAt(0));
        }
        [TestMethod()]
        public void DangNhapTKnull()
        {
            FormCollection c = new FormCollection();
            c.Add("TenDN", null);
            c.Add("MatKhau", "test@123");
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            NguoiDungController user = new NguoiDungController();
            user.ControllerContext = context.Object;
            ViewResult obj = (ViewResult)user.DangNhap(c);
            Assert.AreEqual("Phải nhập tên đăng nhập", obj.ViewData["Loi1"]);
        }
        [TestMethod()]
        public void DangNhapMKnull()
        {
            FormCollection c = new FormCollection();
            c.Add("TenDN", "baitaptest");
            c.Add("MatKhau", null);
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            NguoiDungController user = new NguoiDungController();
            user.ControllerContext = context.Object;
            ViewResult obj = (ViewResult)user.DangNhap(c);
            Assert.AreEqual("Cần nhập mật khẩu", obj.ViewData["Loi2"]);
        }
        [TestMethod()]
        public void DangNhapFAIL()
        {
            FormCollection c = new FormCollection();
            c.Add("TenDN", "ahihihi");
            c.Add("MatKhau", "test@123");
            NguoiDungController user = new NguoiDungController();
            ViewResult obj = (ViewResult)user.DangNhap(c);
            var ar = user.DangNhap() as ViewResult;
            Assert.AreEqual("Tài khoản hoặc mật khẩu không chính xác", ar.ViewData["ThongBao"]);
        }
    }
}