using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_partygame_backend_application.UseCases.Game;
using System;
using System.Collections.Generic;
using System.Text;
using _2_partygame_backend_applicationTests.Mocks;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.ValueObjects;

namespace _2_partygame_backend_application.UseCases.Game.Tests
{
    [TestClass()]
    public class PlayGameTests
    {
        [TestMethod()]
        public void getTaskTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var playGame = new PlayGame(gameRepositoryMock);

            var returnObject = playGame.getTask(new GameEntity(0, "Test"));
            var expected = "testTask";

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod()]
        public void drawCardTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var playGame = new PlayGame(gameRepositoryMock);

            var returnObject = playGame.drawCard();

            Assert.AreEqual(null, returnObject);//no deck and card in a new Game
        }

        [TestMethod()]
        public void rateExecutionOfTaskTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var playGame = new PlayGame(gameRepositoryMock);

            var returnObject = playGame.rateExecutionOfTask(new GameEntity(0, "Test"), 0.0);
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void getExecutionOfTaskRatingTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var playGame = new PlayGame(gameRepositoryMock);

            var returnObject = playGame.getExecutionOfTaskRating(new GameEntity(0, "Test"));
            var expected = 0.0;

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod()]
        public void getNumberExecutionOfTaskRatingsTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var playGame = new PlayGame(gameRepositoryMock);

            var returnObject = playGame.getNumberExecutionOfTaskRatings(new GameEntity(0, "Test"));
            var expected = 3;

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod()]
        public void resetExecutionOfTaskRatingTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var playGame = new PlayGame(gameRepositoryMock);

            var returnObject = playGame.resetExecutionOfTaskRating();
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void getPunishmentTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var playGame = new PlayGame(gameRepositoryMock);

            var returnObject = playGame.getPunishment(new GameEntity(0, "Test"));
            var expected = "test";

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod()]
        public void getActualPlayerTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var playGame = new PlayGame(gameRepositoryMock);


            var returnObject = playGame.getActualPlayer();
            var expected = new PlayerEntity(new GameEntity(0, "Test"), new UserEntity(0, "Test", "Test", "0testPassword!"));

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod()]
        public void changeActualPlayerTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var playGame = new PlayGame(gameRepositoryMock);

            var returnObject = playGame.changeActualPlayer(new PlayerEntity(new GameEntity(0, "Test"), new UserEntity(0, "Test", "Test", "0testPassword!")));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod()]
        public void finishGameTest()
        {
            var gameRepositoryMock = new GameRepositoryMock();
            var playGame = new PlayGame(gameRepositoryMock);

            var returnObject = playGame.finishGame(new GameEntity(0, "Test"));
            var expected = new ReturnObject(true, "test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }
    }
}