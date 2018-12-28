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
    public class LogInOfPhat
    {


        //[TestMethod]
        //public void Login_ValidEmailIDPassword()
        //{

        //    var controller = new AccountController();
        //    var context = new Mock<HttpContextBase>();
        //    var request = new Mock<HttpRequestBase>();
        //    var files = new Mock<HttpFileCollectionBase>();
        //    var file = new Mock<HttpPostedFileBase>();

        //    var model = new LoginViewModel();

        //    model.UserName = "ngohieuphat";
        //    model.Password = "123456";

        //    string returnUrl = null;
        //    controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);

        //    var redirectRoute = controller.Login(model, returnUrl) as RedirectToRouteResult;
        //    //
        //    Assert.IsNotNull(redirectRoute);
        //    Assert.AreEqual("Index", redirectRoute.RouteValues["action"]);
        //    Assert.AreEqual("BangSanPham", redirectRoute.RouteValues["controller"]);
        //}

        [TestMethod]
        public void CreateCustome_Success()
        {
            CustomersController controller = new CustomersController();
            var singup = new Customer
            {
                ID = 1,
                CustomerCode = "aaaa",
                CustomerName = "phat",
                PhoneNumber = "1234567",
                Address = "dia chi",
                //YearOfBirth = DateTime.Parse("Jan ,01, 2009")

            };

            var result = controller.Create(singup) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }
        [TestMethod]
        public void EditCustome_Success()
        {
            CustomersController controller = new CustomersController();
            var singup = new Customer
            {
                ID = 1,
                CustomerCode = "bbb",
                CustomerName = "phat1111",
                PhoneNumber = "09876",
                Address = "dia chi cua phat",
                //YearOfBirth = DateTime.Parse("Jan ,01, 2009")

            };

            var result = controller.Create(singup) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }
        [TestMethod]
        public void View_LogIn()
        {
            // Arrange
            AccountController controller = new AccountController();
            string returnUrl = null;
            // Act
            ViewResult result = controller.Login(returnUrl) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void View_ProductDetail()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Detail(2) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CreateCashBill_Success()
        {
            CashBillsController controller = new CashBillsController();
            var cashbill = new CashBill
            {
               ID = 10,
                BillCode = "xyz",
                CustomerName = " phat",
                PhoneNumber = "1234567",
                Address = "dia chi cu phat",
                Date = DateTime.Parse("Jan, 01, 2009"),
                Shipper = " phat",
                Note = "giao som nha",
                GrandTotal = 12
            };

            var result = controller.Create(cashbill) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }
        [TestMethod]
        public void View_CustomerDetail()
        {
            // Arrange
            CustomersController controller = new CustomersController();
            // Act
            ViewResult result = controller.Details(2) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void EditBill()
        {
            // Arrange
            InstallmentBillDetailsController controller = new InstallmentBillDetailsController();
            // Act
            
            ViewResult result = controller.Edit(2) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteCustomer_Success()
        {
            // Arrange
            CustomersController controller = new CustomersController();
            // Act
            ViewResult result = controller.Delete(1) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ViewCustomerDetail()
        {
            // Arrange
            CustomersController controller = new CustomersController();
            // Act
            ViewResult result = controller.Details(1) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }



    }
}
