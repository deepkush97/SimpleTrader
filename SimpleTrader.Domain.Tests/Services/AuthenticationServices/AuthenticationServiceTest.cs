using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Tests.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTest
    {
        private Mock<IAccountService> _mockAccountService;
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private AuthenticationService _authenticationService;


        [SetUp]
        public void SetUp()
        {
            _mockAccountService = new Mock<IAccountService>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _authenticationService = new AuthenticationService(_mockAccountService.Object, _mockPasswordHasher.Object);

        }

        [Test]
        public async Task Login_WithCorrectPasswordForExisitingUsername_ReturnsAccountForCorrectUsername()
        {
            //Arrange
            string expectedUsername = "testUsername";
            string expectedPassword = "testPassword";
            _mockAccountService.Setup(a => a.GetByUsername(expectedUsername)).ReturnsAsync(
                    new Account
                    {
                        AccountHolder = new User
                        {
                            Username = expectedUsername
                        }
                    }
                );

            _mockPasswordHasher.Setup(e => e.VerifyHashedPassword(It.IsAny<string>(), expectedPassword)).Returns(PasswordVerificationResult.Success);


            //Act
            Account account = await _authenticationService.Login(expectedUsername, expectedPassword);

            //Assert
            string actualUsername = account.AccountHolder.Username;
            Assert.AreEqual(expectedUsername, actualUsername);

        }

        [Test]
        public void Login_WithInCorrectPasswordForExisitingUsername_ThrowsInvalidPasswordExceptionForUsername()
        {
            //Arrange
            string expectedUsername = "testUsername";
            string expectedPassword = "testPassword";
            _mockAccountService.Setup(a => a.GetByUsername(expectedUsername)).ReturnsAsync(
                    new Account
                    {
                        AccountHolder = new User
                        {
                            Username = expectedUsername
                        }
                    }
                );

            _mockPasswordHasher.Setup(e => e.VerifyHashedPassword(It.IsAny<string>(), expectedPassword)).Returns(PasswordVerificationResult.Failed);


            //Act
            InvalidPasswordException exception = Assert.ThrowsAsync<InvalidPasswordException>(() => _authenticationService.Login(expectedUsername, expectedPassword));

            //Assert
            string actualUsername = exception.Username;
            Assert.AreEqual(expectedUsername, actualUsername);

        }

        [Test]
        public void Login_WithNonExisitingUsername_ThrowsInvalidPasswordExceptionForUsername()
        {
            //Arrange
            string expectedUsername = "testUsername";
            string expectedPassword = "testPassword";

            _mockPasswordHasher.Setup(e => e.VerifyHashedPassword(It.IsAny<string>(), expectedPassword)).Returns(PasswordVerificationResult.Failed);


            //Act
            UserNotFoundException exception = Assert.ThrowsAsync<UserNotFoundException>(() => _authenticationService.Login(expectedUsername, expectedPassword));

            //Assert
            string actualUsername = exception.Username;
            Assert.AreEqual(expectedUsername, actualUsername);

        }

        [Test]
        public async Task Register_WithPasswordNotMatching_ReturnsPasswordNotMatch()
        {
            RegistrationResult expected = RegistrationResult.PasswordDoNotMatch;

            string password = "password";
            string confirmPassword = "confirmPassword";
            RegistrationResult actual = await _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), password, confirmPassword);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public async Task Register_WithAlreadyExistingEmail_ReturnsEmailAlreadyExists()
        {

            string email = "test@gmail.com";
            _mockAccountService.Setup(s => s.GetByEmail(email)).ReturnsAsync(new Account());

            RegistrationResult expected = RegistrationResult.EmailAlreadyExists;

            RegistrationResult actual = await _authenticationService.Register(email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public async Task Register_WithAlreadyExistingUsername_ReturnsUsernameAlreadyExists()
        {

            string username = "test123";
            _mockAccountService.Setup(s => s.GetByUsername(username)).ReturnsAsync(new Account());

            RegistrationResult expected = RegistrationResult.UsernameAlreadyExists;

            RegistrationResult actual = await _authenticationService.Register( It.IsAny<string>(), username, It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public async Task Register_WithNonExistingUserAndMatchingPassword_ReturnsSuccess()
        {
            RegistrationResult expected = RegistrationResult.Success;

            RegistrationResult actual = await _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);

        }

    }
}
