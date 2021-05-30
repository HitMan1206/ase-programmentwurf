using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_partygame_backend_application.UseCases.User;
using System;
using System.Collections.Generic;
using System.Text;
using _3_partygame_backend_domain.Services;
using _2_partygame_backend_applicationTests.Mocks;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Entities;
using System.Collections.ObjectModel;

namespace _2_partygame_backend_application.UseCases.User.Tests
{
    [TestClass]
    public class ViewUserTests
    {
        [TestMethod]
        public void getAllUsersTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var viewUser = new ViewUser(userRepositoryMock);

            var returnObject = viewUser.getAllUsers();
            var expected = new Collection<UserEntity>();

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod]
        public void getUserByIdTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var viewUser = new ViewUser(userRepositoryMock);

            var returnObject = viewUser.getUserById(0);
            var expected = new UserEntity(0, "test", "testuser", "0testPassword!");

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod]
        public void getUserbyEmailTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var viewUser = new ViewUser(userRepositoryMock);

            var returnObject = viewUser.getUserbyEmail("test");
            var expected = new UserEntity(0, "test", "testuser", "0testPassword!");

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod]
        public void getHistoryTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var viewUser = new ViewUser(userRepositoryMock);

            var returnObject = viewUser.getHistory();
            var expected = new HistoryEntity(0, new UserEntity(0, "test", "testuser", "0testPassword!"));

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod]
        public void getAllFriendsTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var viewUser = new ViewUser(userRepositoryMock);

            var returnObject = viewUser.getAllFriends();
            var expected = new Collection<FriendEntity>();

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod]
        public void getFriendByIdTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var viewUser = new ViewUser(userRepositoryMock);

            var returnObject = viewUser.getFriendById(0);

            Assert.AreEqual(null, returnObject); //no friend exist
        }

        [TestMethod]
        public void getFriendByEmailTest()
        {
            var userRepositoryMock = new UserRepositoryMock();
            var viewUser = new ViewUser(userRepositoryMock);

            var returnObject = viewUser.getFriendByEmail("test");

            Assert.AreEqual(null, returnObject); //no friend exists
        }
    }
}