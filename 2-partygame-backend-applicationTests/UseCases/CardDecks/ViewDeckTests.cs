using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_partygame_backend_application.UseCases.CardDecks;
using System;
using System.Collections.Generic;
using System.Text;
using _2_partygame_backend_applicationTests.Mocks;
using System.Collections.ObjectModel;
using _3_partygame_backend_domain.ValueObjects;
using _3_partygame_backend_domain.Entities;

namespace _2_partygame_backend_application.UseCases.CardDecks.Tests
{
    [TestClass]
    public class ViewDeckTests
    {
        [TestMethod]
        public void getAllDecksTest()
        {

            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var viewDeck = new ViewDeck(carddeckRepositoryMock);
            var expectedDecks = new Collection<CarddeckEntity>();
            expectedDecks.Add(new CarddeckEntity(0, "test", 0));

            var expected = expectedDecks;
            var returnObject = viewDeck.getAllDecks();

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod]
        public void getDeckByIdTest()
        {
            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var viewDeck = new ViewDeck(carddeckRepositoryMock);

            var expected = new CarddeckEntity(0, "test", 0);
            var returnObject = viewDeck.getDeckById(0);

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod]
        public void getCardsInDeckTest()
        {
            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var viewDeck = new ViewDeck(carddeckRepositoryMock);
            var expectedCards = new Collection<TaskCard>();
            expectedCards.Add(new TaskCard(1, "Test task.", "Test penalty.", "Test Card"));

            var expected = expectedCards;
            var returnObject = viewDeck.getCardsInDeck(new CarddeckEntity(0, "test", 0));

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }

        [TestMethod]
        public void getGamemodesTest()
        {
            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var viewDeck = new ViewDeck(carddeckRepositoryMock);
            var expectedGamemodes = new Collection<Gamemode>();
            expectedGamemodes.Add(new Gamemode(0, "testgamemode"));

            var expected = expectedGamemodes;
            var returnObject = viewDeck.getGamemodes(0);

            Assert.AreEqual(expected.GetType(), returnObject.GetType());
        }
    }
}