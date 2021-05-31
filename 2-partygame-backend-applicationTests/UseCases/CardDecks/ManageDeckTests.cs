using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_partygame_backend_application.UseCases.CardDecks;
using System;
using System.Collections.Generic;
using System.Text;
using _2_partygame_backend_applicationTests.Mocks;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;

namespace _2_partygame_backend_application.UseCases.CardDecks.Tests
{
    [TestClass]
    public class ManageDeckTests
    {

        [TestMethod]
        public void updateDeckRatingTest()
        {

            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var manageDeck = new ManageDeck(carddeckRepositoryMock);
            var returnObject = manageDeck.updateDeckRating(0, 0);
            var expected = new ReturnObject(true, "Test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod]
        public void createDeckTest()
        {

            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var manageDeck = new ManageDeck(carddeckRepositoryMock);

            var returnObject = manageDeck.createDeck(0, "test", 0);
            var expected = new ReturnObject(true, "Test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod]
        public void addToGamemodeTest()
        {
            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var manageDeck = new ManageDeck(carddeckRepositoryMock);
            var gamemode = new Gamemode(0, "testmode");

            var returnObject = manageDeck.addToGamemode(0, gamemode);
            var expected = new ReturnObject(true, "Test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod]
        public void removeFromGamemodeTest()
        {
            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var manageDeck = new ManageDeck(carddeckRepositoryMock);
            var gamemode = new Gamemode(0, "testmode");

            var returnObject = manageDeck.removeFromGamemode(0, gamemode);
            var expected = new ReturnObject(false, "deck does not exist");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }
    }
}