using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_partygame_backend_application.UseCases.Game;
using System;
using System.Collections.Generic;
using System.Text;
using _2_partygame_backend_applicationTests.Mocks;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.Entities;
using System.Collections.ObjectModel;

namespace _2_partygame_backend_application.UseCases.Game.Tests
{
    [TestClass()]
    public class ViewGameTests
    {
        [TestMethod()]
        public void getGameByIdTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var viewGame = new ViewGame(gameRepositoryMock);

            var returnObject = viewGame.getGameById(2);
            var expected = new GameEntity(0, "Test");

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod()]
        public void getAllGamesTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var viewGame = new ViewGame(gameRepositoryMock);

            var returnObject = viewGame.getAllGames();
            var expected = new Collection<GameEntity>();

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod()]
        public void getDecksForGameTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var viewGame = new ViewGame(gameRepositoryMock);

            var returnObject = viewGame.getDecksForGame(0);
            var expected = new Collection<CarddeckEntity>();

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }
    }
}