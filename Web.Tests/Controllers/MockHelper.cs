using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Web;

namespace Web.Tests.Controllers
{
    public class MockHelper
    {

        public Mock<HttpSessionStateBase> Session { get; set; }
        private Mock<HttpContextBase> Context { get; set; }
        public MockHelper()
        {
            Session = new Mock<HttpSessionStateBase>();
            Context = new Mock<HttpContextBase>();
        }
        public Mock<HttpContextBase> MakeFakeContext()
        {
            Context.Setup(c => c.Session).Returns(Session.Object);
            return Context;
        }
    }
}