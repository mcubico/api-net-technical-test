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
        [TestMethod]
        public async Task UsernameToSignInIsRequired()
        {
            try
            {
                // Preparación
                var signInManagerMock = new SignInManagerMock();
                var configurationGetJwtKeyMock = new ConfigurationGetJwtKeyMock();
                var controller = new AccountController(signInManagerMock, configurationGetJwtKeyMock);
                var userData = new SingInModel
                {
                    Password = "password",
                };

                // Ejecución
                var response = await controller.Post(userData) as BadRequestObjectResult;
            }
            catch (Exception ex)
            {

                Assert.AreEqual("Value cannot be null. (Parameter 'userName')", ex.Message);
            }
        }

        [TestMethod]
        public async Task PasswordToSignInIsRequired()
        {
            try
            {
                // Preparación
                var signInManagerMock = new SignInManagerMock();
                var configurationGetJwtKeyMock = new ConfigurationGetJwtKeyMock();
                var controller = new AccountController(signInManagerMock, configurationGetJwtKeyMock);
                var userData = new SingInModel
                {
                    Username = "password",
                };

                // Ejecución
                var response = await controller.Post(userData) as BadRequestObjectResult;
            }
            catch (Exception ex)
            {

                Assert.AreEqual("Value cannot be null. (Parameter 'password')", ex.Message);
            }
        }

        [TestMethod]
        public async Task UsernameMostBeAnEmail()
        {
            // Preparación
            var signInManagerMock = new SignInManagerMock();
            var configurationGetJwtKeyMock = new ConfigurationGetJwtKeyMock();
            var controller = new AccountController(signInManagerMock, configurationGetJwtKeyMock);
            var userData = new SingInModel
            {
                Username = "username",
                Password = "password",
            };

            // Ejecución
            var response = await controller.Post(userData) as BadRequestObjectResult;

            // Verificación
            Assert.AreEqual(StatusCodes.Status400BadRequest, response?.StatusCode);
            Assert.AreEqual("Username or password incorrect", response?.Value);
        }

        [TestMethod]
        public async Task CanBeAuthenticatedWithTheCorrectCredentials()
        {
            // Preparación
            var signInManagerMock = new SignInManagerMock();
            var configurationGetJwtKeyMock = new ConfigurationGetJwtKeyMock();
            var controller = new AccountController(signInManagerMock, configurationGetJwtKeyMock);
            var userData = new SingInModel
            {
                Username = "mcubico33@gmail.com",
                Password = "4dm1n***",
            };

            // Ejecución
            var response = await controller.Post(userData);

            // Verificación
            Assert.AreEqual(StatusCodes.Status200OK, response);
        }
    }
}
