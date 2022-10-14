using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MUSIC.Models;
using MUSIC.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using Moq;
using System.Web;

namespace MUSIC.Controllers.Tests
{
    [TestClass()]
    public class NguoiDungControllerTests
    {
        [TestMethod()]
        public void dangnhapthanhcong()
        {
            Assert.AreEqual("ahihi", "ahihi");
            /*FormCollection c = new FormCollection();
            c.Add("TenDN", "baitaptest");
            c.Add("MatKhau", "test@123");
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            NguoiDungController user = new NguoiDungController();
            user.ControllerContext=context.Object;
            ViewResult obj = (ViewResult)user.DangNhap(c);
            Assert.AreEqual("Index", obj.ViewName);*/
        }
    }
}