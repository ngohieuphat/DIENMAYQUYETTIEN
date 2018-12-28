using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Controllers;
using Web.Models;
using Moq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Transactions;
using System.Web.Routing;
using System.Linq;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ThemHoaDonTest()
        {
            var controller = new BangSanPhamController();
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var files = new Mock<HttpFileCollectionBase>();
            var file = new Mock<HttpPostedFileBase>();
            context.Setup(c => c.Request).Returns(request.Object);
            request.Setup(r => r.Files).Returns(files.Object);
            files.Setup(f => f["HinhAnh"]).Returns(file.Object);
            file.Setup(f => f.ContentLength).Returns(1);
            context.Setup(c => c.Server.MapPath("~/App_Data")).Returns("~/App_Data");
            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);

            var db = new DmQT12Entities();
            var model = new Product();
            model.ProductTypeID = db.ProductTypes.First().ID;
            model.ProductName = "TenSP";
            model.ProductCode = "MaSP";
            model.OriginPrice = 123;
            model.SalePrice = 456;
            model.InstallmentPrice = 789;
            model.Quantity = 10;

            using (var scope = new TransactionScope())
            {
                var result0 = controller.Create(model) as RedirectToRouteResult;
                Assert.IsNotNull(result0);
                file.Verify(f => f.SaveAs(It.Is<string>(s => s.StartsWith("~/App_Data/"))));
                Assert.AreEqual("Index", result0.RouteValues["action"]);

                file.Setup(f => f.ContentLength).Returns(0);
                var result1 = controller.Create(model) as ViewResult;
                Assert.IsNotNull(result1);
                Assert.IsInstanceOfType(result1.ViewData["Loai_id"], typeof(SelectList));
            }
        }
    }
}
