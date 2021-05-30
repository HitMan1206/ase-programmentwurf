using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _2_partygame_backend_applicationTests.Mocks
{
    class CarddeckRepositoryMock : CarddeckRepository
    {
        public ReturnObject addCard(TaskCard card)
        {
            return new ReturnObject(true, "Add Card Test.");
        }

        public ReturnObject addToGamemode(Gamemode gamemode)
        {
            return new ReturnObject(true, "Add to Gamemode Test");
        }

        public ReturnObject create(string name, Carddeckgenre genre)
        {
            return new ReturnObject(true, "Create Deck Test");
        }

        public Collection<CarddeckEntity> getAllDecks()
        {
            Collection<CarddeckEntity> decks = new Collection<CarddeckEntity>();
            decks.Add(new CarddeckEntity(0, "testdeck", new Carddeckgenre(0, "testgenre", new RecommendedAge(0, "18+", 18))));
            return decks;
        }

        public CarddeckEntity getById(int deckId)
        {
            return new CarddeckEntity(0, "testdeck", new Carddeckgenre(0, "testgenre", new RecommendedAge(0, "18+", 18)));
        }

        public Collection<TaskCard> getCardsInDeck(CarddeckEntity deck)
        {
            Collection<TaskCard> cards = new Collection<TaskCard>();
            cards.Add(new TaskCard(0, "testtask", "testpenalty", "testcard"));
            return cards;
        }

        public Collection<Gamemode> getGamemodesWhereDeckIsIn()
        {
            Collection<Gamemode> modes = new Collection<Gamemode>();
            modes.Add(new Gamemode(0, "testgamemode"));
            return modes;
        }

        public Carddeckgenre getGenre(CarddeckEntity deck)
        {
            return new Carddeckgenre(0, "testgenre", new RecommendedAge(0, "18+", 18));
        }

        public ReturnObject rate(CarddeckEntity deck, double rating)
        {
            return new ReturnObject(true, "Rate Deck Test");
        }

        public ReturnObject removeFromGameode(Gamemode gamemode)
        {
            return new ReturnObject(true, "Remove from Gamemode Card");
        }

        public ReturnObject update(CarddeckEntity deck)
        {
            return new ReturnObject(true, "Update Deck Test.");
        }
    }
}
