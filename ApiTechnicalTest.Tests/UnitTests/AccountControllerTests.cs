using ApiTechnicalTest.Presentation.Controllers;
using ApiTechnicalTest.Presentation.Models;
using ApiTechnicalTest.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechnicalTest.Tests.UnitTests
{
    [TestClass]
    public class AccountControllerTests
    {
        private readonly SignInManagerValidateRequirementDataMock _signInManagerValidateRequirementDataMock;
        private readonly ConfigurationGetJwtKeyMock _configurationGetJwtKeyMock;
        private AccountController _controller;

        public AccountControllerTests()
        {
            _signInManagerValidateRequirementDataMock = new SignInManagerValidateRequirementDataMock();
            _configurationGetJwtKeyMock = new ConfigurationGetJwtKeyMock();
            _controller = new AccountController(_signInManagerValidateRequirementDataMock, _configurationGetJwtKeyMock);
        }

        [TestMethod]
        public async Task UsernameToSignInIsRequired()
        {
            try
            {
                // Preparatión
                var userData = new SingInModel
                {
                    Password = "password",
                };

                // Execution
                var response = await _controller.Post(userData);
            }
            catch (Exception ex)
            {
                // Verification
                Assert.AreEqual("Value cannot be null. (Parameter 'userName')", ex.Message);
            }
        }

        [TestMethod]
        public async Task PasswordToSignInIsRequired()
        {
            try
            {
                // Preparatión
                var userData = new SingInModel
                {
                    Username = "password",
                };

                // Execution
                var response = await _controller.Post(userData);
            }
            catch (Exception ex)
            {
                // Verification
                Assert.AreEqual("Value cannot be null. (Parameter 'password')", ex.Message);
            }
        }

        [TestMethod]
        public async Task UsernameMostBeAnEmail()
        {
            // Preparatión
            var userData = new SingInModel
            {
                Username = "username",
                Password = "password",
            };

            // Execution
            var response = await _controller.Post(userData);

            // Verification
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
            var badRequestResponse = (BadRequestObjectResult)response;
            Assert.AreEqual(StatusCodes.Status400BadRequest, badRequestResponse?.StatusCode);
            Assert.AreEqual("Username or password incorrect", badRequestResponse?.Value);
        }

        [TestMethod]
        public async Task CanBeAuthenticatedWithTheCorrectCredentials()
        {
            // Preparatión
            var userData = new SingInModel
            {
                Username = "mcubico33@gmail.com",
                Password = "4dm1n***",
            };

            // Execution
            _controller = new AccountController(new SignInManagerMock(), _configurationGetJwtKeyMock);
            var response = await _controller.Post(userData);

            // Verification
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            var okResponse = (OkObjectResult)response;
            Assert.AreEqual(StatusCodes.Status200OK, okResponse?.StatusCode);
        }
    }
}
