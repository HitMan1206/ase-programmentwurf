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


        public ReturnObject addToGamemode(int deckId, Gamemode gamemode)
        {
            return new ReturnObject(true, "Add to Gamemode Test");
        }

        public ReturnObject create(int id, string name, int genre)
        {
            return new ReturnObject(true, "Create deck Test");
        }

        public Collection<CarddeckEntity> getAllDecks()
        {
            Collection<CarddeckEntity> decks = new Collection<CarddeckEntity>();
            decks.Add(new CarddeckEntity(0, "testdeck", 0));
            return decks;
        }

        public CarddeckEntity getById(int deckId)
        {
            return new CarddeckEntity(0, "testdeck", 0);
        }

        public Collection<TaskCard> getCardsInDeck(CarddeckEntity deck)
        {
            Collection<TaskCard> cards = new Collection<TaskCard>();
            cards.Add(new TaskCard(0, "testtask", "testpenalty", "testcard"));
            return cards;
        }

        public Collection<Gamemode> getGamemodesWhereDeckIsIn(int deckId)
        {
            return new Collection<Gamemode>();
        }

        public Carddeckgenre getGenre(CarddeckEntity deck)
        {
            return new Carddeckgenre(0, "testgenre", new RecommendedAge(0, "18+", 18));
        }

        public ReturnObject rate(CarddeckEntity deck, double rating)
        {
            return new ReturnObject(true, "Rate Deck Test");
        }

        public ReturnObject removeFromGameode(int deckId, Gamemode gamemode)
        {
            return new ReturnObject(true, "Remove From Gamemode Test.");
        }

        public ReturnObject update(CarddeckEntity deck)
        {
            return new ReturnObject(true, "Update Deck Test.");
        }

        public ReturnObject updateGamesPlayed(int deckId)
        {
            return new ReturnObject(true, "Update Games Played Test.");
        }

        public ReturnObject updateRating(int deckId, double rating)
        {
            return new ReturnObject(true, "Update Rating Test.");
        }
    }
}
