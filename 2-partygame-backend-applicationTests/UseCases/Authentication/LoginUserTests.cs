using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_partygame_backend_application.UseCases.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services.auth;
using _3_partygame_backend_domain.Services;
using _2_partygame_backend_applicationTests.Mocks;

namespace _2_partygame_backend_application.UseCases.Authentication.Tests
{
    [TestClass]
    public class LoginUserTests
    {
        [TestMethod]
        public void loginUserTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var authServiceMock = new AuthServiceMock();
            var loginUser = new LoginUser(userRepositoryMock, authServiceMock);
            var expected = new ReturnObject(true, "Logged in.");

            var returnObject = loginUser.loginUser("test@test.com", "0testPassword!");
            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }
    }
}