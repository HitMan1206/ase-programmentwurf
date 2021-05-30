using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_partygame_backend_application.UseCases.Game;
using System;
using System.Collections.Generic;
using System.Text;
using _2_partygame_backend_applicationTests.Mocks;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.ValueObjects;
using _3_partygame_backend_domain.Entities.AggregateEntities;

namespace _2_partygame_backend_application.UseCases.Game.Tests
{
    [TestClass()]
    public class ManageGameTests
    {
        [TestMethod()]
        public void createGameTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.createGame("test");
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void changeStatusTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.changeStatus(new Status(0, "test"));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void changeActualCardTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.changeActualCard(new TaskCard(0, "testtask", "testpenalty", "testcard"));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void closeGameTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.closeGame(new GameEntity(0, "Test"));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void invitePlayerTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.invitePlayer(new FriendEntity(new UserEntity(1, "email", "testuser", "0testPassword!"), new UserEntity(1, "email", "testuser", "0testPassword!")));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void addPlayerTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.addPlayer(new PlayerEntity(new GameEntity(0, "Test"), new UserEntity(1, "testmail", "testuser", "0testPassword!")));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void removePlayerTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.removePlayer(0);
            var expected = new ReturnObject(false, "player does not exist");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void changeGamemodeTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.changeGamemode(new Gamemode(0, "testgamemode"));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void removeDeckTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.removeDeck(0);
            var expected = new ReturnObject(false, "deck does not exist");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void removeAllDecksFromGameTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.removeAllDecksFromGame(new GameEntity(0, "Test"));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void addDeckTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.addDeck(new CarddeckEntity(0, "testdeck", new Carddeckgenre(0, "testgenre", new RecommendedAge(0, "18+", 18))));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }
    }
}