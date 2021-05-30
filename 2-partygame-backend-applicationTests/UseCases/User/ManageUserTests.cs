using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_partygame_backend_application.UseCases.User;
using System;
using System.Collections.Generic;
using System.Text;
using _2_partygame_backend_applicationTests.Mocks;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;

namespace _2_partygame_backend_application.UseCases.User.Tests
{
    [TestClass()]
    public class ManageUserTests
    {
        [TestMethod()]
        public void changeUserStatusTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var changePasswordServiceMock = new ChangePasswordServiceMock();
            var manageUser = new ManageUser(userRepositoryMock, changePasswordServiceMock);

            var returnObject = manageUser.changeUserStatus(new Status(0, "Offline"));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void changePasswordTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var changePasswordServiceMock = new ChangePasswordServiceMock();
            var manageUser = new ManageUser(userRepositoryMock, changePasswordServiceMock);

            var returnObject = manageUser.changePassword(0, "0testPassword!", "1testPassword!");
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void deleteUserTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var changePasswordServiceMock = new ChangePasswordServiceMock();
            var manageUser = new ManageUser(userRepositoryMock, changePasswordServiceMock);

            var returnObject = manageUser.deleteUser(0);
            var expected = new ReturnObject(false, "user does not exist");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void addFriendTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var changePasswordServiceMock = new ChangePasswordServiceMock();
            var manageUser = new ManageUser(userRepositoryMock, changePasswordServiceMock);

            var returnObject = manageUser.addFriend(new FriendEntity(new UserEntity(0, "test", "testuser", "0testPassword!"), new UserEntity(0, "test1", "testuser", "0testPassword!")));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void removeFriendTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var changePasswordServiceMock = new ChangePasswordServiceMock();
            var manageUser = new ManageUser(userRepositoryMock, changePasswordServiceMock);

            var returnObject = manageUser.removeFriend(new FriendEntity(new UserEntity(0, "test", "testuser", "0testPassword!"), new UserEntity(0, "test1", "testuser", "0testPassword!")));
            var expected = new ReturnObject(false, "friend does not exist");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void createHistoryTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var changePasswordServiceMock = new ChangePasswordServiceMock();
            var manageUser = new ManageUser(userRepositoryMock, changePasswordServiceMock);

            var returnObject = manageUser.createHistory(0);
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void updateHistoryTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var changePasswordServiceMock = new ChangePasswordServiceMock();
            var manageUser = new ManageUser(userRepositoryMock, changePasswordServiceMock);

            var returnObject = manageUser.updateHistory(new HistoryEntity(0, new UserEntity(0, "test", "testuser", "0testPassword!")));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }
    }
}