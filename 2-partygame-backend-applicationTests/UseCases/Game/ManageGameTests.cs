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
            var game = new GameEntity(0, "test");

            var returnObject = manageGame.createGame(game);
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void changeStatusTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.changeStatus(0, new Status(0, "test"));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void changeActualCardTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.changeActualCard(0,0);
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
        public void addPlayerTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.addPlayer(0,0);
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void removePlayerTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.removePlayer(0,0);
            var expected = new ReturnObject(false, "player does not exist");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void changeGamemodeTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.changeGamemode(0, new Gamemode(0, "testgamemode"));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void removeDeckTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.removeDeck(0,0);
            var expected = new ReturnObject(false, "deck does not exist");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }


        [TestMethod()]
        public void addDeckTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var manageGame = new ManageGame(gameRepositoryMock);

            var returnObject = manageGame.addDeck(0,0);
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }
    }
}