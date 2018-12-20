using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Mvc;
using Web.Models;
using Web.Controllers;
using System.Collections.Generic;

namespace Web.Tests.Controllers {
    [TestClass]
    public class BangSanPhamTest {
        [TestMethod]
        public void IndexTest() {
            var controller = new BangSanPhamController();
            var result = controller.Index() as ViewResult;
            var db = new DmQT12Entities();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<Product>));
            Assert.AreEqual(db.Products.Count(), ((List<Product>)result.Model).Count);

            
        }
    }
}
