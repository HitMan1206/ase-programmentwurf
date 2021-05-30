using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_partygame_backend_application.UseCases.CardDecks;
using System;
using System.Collections.Generic;
using System.Text;
using _2_partygame_backend_applicationTests.Mocks;
using _3_partygame_backend_domain.ValueObjects;
using _3_partygame_backend_domain.Services;

namespace _2_partygame_backend_application.UseCases.CardDecks.Tests
{
    [TestClass()]
    public class AddNewCardTests
    {
        [TestMethod()]
        public void addNewCardTest()
        {
            var carddeckRepositoryMock = new CarddeckRepositoryMock();
            var addNewCard = new AddNewCard(carddeckRepositoryMock);
            var card = new TaskCard(1, "Test task.", "Test penalty.", "Test Card");
            var expected = new ReturnObject(true, "Test");

            var returnObject = addNewCard.addNewCard(card);

            Assert.AreEqual(expected.isSuccess(), returnObject.isSuccess());
        }
    }
}