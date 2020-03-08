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
        private HomeController _controller;
        [TestInitialize]
        public void Init()
        {
            var logger_mock = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(logger_mock.Object);
        }


        [TestMethod]
        public void Index_Return_View() {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void Blog_Returns_View()
        {
            var result = _controller.Blog();
            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ContactUs_Returns_View()
        {
            var result = _controller.ContactUs();
            Assert.IsType<ViewResult>(result);
        }

        [TestMethod, ExpectedException(typeof(ApplicationException))]
        public void ThrowError_Throw_ApplicationException()
        {
            var result = _controller.ThrowError(null);
        }

        [TestMethod]
        public void ThrowError_Throw_ApplicationException2()
        {
            const string expected_exception_message = "Hello World!";
            var exception = Assert.Throws<ApplicationException>(() => _controller.ThrowError(expected_exception_message));
            Assert.Equal(expected_exception_message, exception.Message);
        }

        [TestMethod]
        public void Error404_Returns_View()
        {
            var result = _controller.NotFound();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ErrorStatus_404_Redirect_to_Error404()
        {
            const string status_code = "404";
            var result = _controller.ThrowError(status_code);

            var redirect_to_action = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirect_to_action.ControllerName);
            Assert.Equal(nameof(HomeController.NotFound), redirect_to_action.ActionName);
        }


    }
}
