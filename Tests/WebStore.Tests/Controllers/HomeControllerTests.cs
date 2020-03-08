using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Controllers;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_Return_View() {
            var logger_mock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(logger_mock.Object);
            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
        }

    }
}
