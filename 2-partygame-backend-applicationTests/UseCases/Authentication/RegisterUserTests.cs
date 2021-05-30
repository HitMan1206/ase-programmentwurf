using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_partygame_backend_application.UseCases.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using _2_partygame_backend_applicationTests.Mocks;
using _3_partygame_backend_domain.Services;

namespace _2_partygame_backend_application.UseCases.Authentication.Tests
{
    [TestClass()]
    public class RegisterUserTests
    {
        [TestMethod()]
        public void registerUserTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var registerUser = new RegisterUser(userRepositoryMock);
            var expected = new ReturnObject(false, "User already exist.");

            var returnObject = registerUser.registerUser("test@test.com", "0testPassword!", "testuser");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }
    }
}