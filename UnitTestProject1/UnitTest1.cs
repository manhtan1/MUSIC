using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MUSIC.Controllers;
using System.Web.Mvc;

namespace UnitTestProject1
{
    [TestClass]
    public class DangNhap
    {
        /*private object ViewResult;*/

        [TestMethod]
        public void TestMethod1()
        {
            NguoiDungController test = new NguoiDungController();
            ViewResult obj = (ViewResult)test.DangNhap("ádasd", "dsdsd");
            Assert.AreEqual("trang chủ", obj.ViewName);
        }
        
    }
}
