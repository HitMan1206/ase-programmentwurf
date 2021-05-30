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
        public void rateDeckTest()
        {

            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var manageDeck = new ManageDeck(carddeckRepositoryMock);
            var deck = new CarddeckEntity(0, "test", new Carddeckgenre(0, "testgenre", new RecommendedAge(0, "16+", 16)));
            var returnObject = manageDeck.rateDeck(deck, 3.5);
            var expected = new ReturnObject(true, "Test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod]
        public void createDeckTest()
        {

            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var manageDeck = new ManageDeck(carddeckRepositoryMock);

            var returnObject = manageDeck.createDeck("test", new Carddeckgenre(0, "testgenre", new RecommendedAge(0, "0+", 0)));
            var expected = new ReturnObject(true, "Test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod]
        public void updateDeckTest()
        {

            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var manageDeck = new ManageDeck(carddeckRepositoryMock);
            var deck = new CarddeckEntity(0, "test", new Carddeckgenre(0, "testgenre", new RecommendedAge(0, "16+", 16)));

            var returnObject = manageDeck.updateDeck(deck);
            var expected = new ReturnObject(true, "Test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod]
        public void addToGamemodeTest()
        {
            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var manageDeck = new ManageDeck(carddeckRepositoryMock);
            var gamemode = new Gamemode(0, "testmode");

            var returnObject = manageDeck.addToGamemode(gamemode);
            var expected = new ReturnObject(true, "Test");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }

        [TestMethod]
        public void removeFromGamemodeTest()
        {
            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var manageDeck = new ManageDeck(carddeckRepositoryMock);
            var gamemode = new Gamemode(0, "testmode");

            var returnObject = manageDeck.removeFromGamemode(gamemode);
            var expected = new ReturnObject(false, "deck does not exist");

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }
    }
}