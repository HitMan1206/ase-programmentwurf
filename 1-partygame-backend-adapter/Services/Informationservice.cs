﻿using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Context;
using _1_partygame_backend_adapter.APIModels.Game;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.CarddeckMappings;
using _1_partygame_backend_adapter.Mappings.GameMappings;
using _2_partygame_backend_application.UseCases.CardDecks;
using _3_partygame_backend_domain.AggregateEntities;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.Services
{
    public class Informationservice: CarddeckRepository
    {
        private readonly DatabaseContext _context;
        private readonly CarddeckBridge _bridge = new CarddeckBridge();
        private readonly GameBridge _gamebridge = new GameBridge();
        private readonly ReturnObjectBridge _returnBridge = new ReturnObjectBridge();
        private readonly AddNewCard _addNewCard;
        private readonly ManageDeck _manageDeck;
        private readonly ViewDeck _viewDeck;

        public Informationservice(DatabaseContext context, AddNewCard addNewCard, ManageDeck manageDeck, ViewDeck viewDeck)
        {
            _context = context;
            _addNewCard = addNewCard;
            _manageDeck = manageDeck;
            _viewDeck = viewDeck;
        }

       /* public Carddeck getDeck(int deckId)
        {
            return _context.Carddeck.Where(item => item.Id == deckId).FirstOrDefault();
        }

        public IEnumerable<Carddeck> getDecks()
        {
            return _context.Carddeck.ToList();
        }

        public APIReturnObject addNewCard(int deckId, TaskCard newCard)
        {
            CarddeckEntity deck = _viewDeck.getDeckById(deckId);
            DeckIncludesCardEntity newDeckIncludescard = new DeckIncludesCardEntity(deck, newCard);
            ReturnObject returnObject = _addNewCard.addNewCard(newCard);
            if (returnObject.isSuccess())
            {
                _context.Taskcard.Add(_bridge.mapToTaskcardFrom(newCard));
                _context.DeckIncludesCard.Add(_bridge.mapToDeckIncludesCardFrom(newDeckIncludescard));
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);

        }

        public APIReturnObject addDeckRating(int deckId, double rating)
        {
            CarddeckEntity deck = _viewDeck.getDeckById(deckId);

            double newRating;

            double actualRating = (deck.Rating * deck.NumberOfRatings);
            int newNumberOfRatings = (deck.NumberOfRatings + 1);

            newRating = (actualRating + rating) / newNumberOfRatings;

            ReturnObject returnObject = _manageDeck.rateDeck(deck, newRating);

            if (returnObject.isSuccess())
            {
                _context.Carddeck.Where(item => item.Id == deckId).FirstOrDefault().Rating = newRating;
                _context.Carddeck.Where(item => item.Id == deckId).FirstOrDefault().NumberOfRatings = newNumberOfRatings;
                _context.Entry(_bridge.mapToCarddeckFrom(deck)).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }
        */
        public ReturnObject create(int id, string name, _3_partygame_backend_domain.ValueObjects.Carddeckgenre genre)
        {
            _context.Carddeck.Add(new Carddeck(id, _bridge.mapToCarddeckgenreFrom(genre), name, 0.0, 0, 0));
            _context.SaveChanges();
            return new ReturnObject(true, "Deck created");
        }

        public ReturnObject updateRating(int deckId, double rating)
        {
            _context.Carddeck.Where(item => item.Id == deckId).FirstOrDefault().NumberOfRatings = _context.Carddeck.Where(item => item.Id == deckId).FirstOrDefault().NumberOfRatings + 1;
            _context.Carddeck.Where(item => item.Id == deckId).FirstOrDefault().Rating = rating;
            _context.SaveChanges();
            return new ReturnObject(true, "rating updated");
        }

        public ReturnObject updateGamesPlayed(int deckId)
        {
            _context.Carddeck.Where(item => item.Id == deckId).FirstOrDefault().GamesPlayed = _context.Carddeck.Where(item => item.Id == deckId).FirstOrDefault().GamesPlayed + 1;
            _context.SaveChanges();
            return new ReturnObject(true, "games played updated");
        }

        public ReturnObject addCard(TaskCard card)
        {
            _context.Taskcard.Add(_bridge.mapToTaskcardFrom(card));
            _context.SaveChanges();
            return new ReturnObject(true, "Card added");
        }

        public CarddeckEntity getById(int deckId)
        {
            var deck = _context.Carddeck.Where(item => item.Id == deckId).FirstOrDefault();
            return _bridge.mapToCarddeckEntityFrom(deck);
        }

        public Collection<CarddeckEntity> getAllDecks()
        {
            Collection<Carddeck> decks = new Collection<Carddeck>();
            foreach(Carddeck a in _context.Carddeck)
            {
                decks.Add(a);
            }
            return _bridge.mapToCarddeckEntityCollectionFrom(decks);
        }

        public Collection<TaskCard> getCardsInDeck(CarddeckEntity deck)
        {
            var cardsInDeck = _context.DeckIncludesCard.Where(item => item.Deck.Id == deck.getId());
            var mappedCards = new Collection<TaskCard>();
            foreach(DeckIncludesCard a in cardsInDeck)
            {
                mappedCards.Add(_bridge.mapToTaskCardFrom(a.Card));
            }
            return mappedCards;
        }

        public ReturnObject addToGamemode(int deckId, Gamemode gamemode)
        {
            _context.GamemodeIncludesDeck.Add(new GamemodeIncludesDeck(_gamebridge.mapToGamemodeFrom(gamemode), _context.Carddeck.Where(item => item.Id == deckId).FirstOrDefault()));
            _context.SaveChanges();
            return new ReturnObject(true, "deck added to gamemode");
        }

        public ReturnObject removeFromGameode(int deckId, Gamemode gamemode)
        {
            var removeItem = _context.GamemodeIncludesDeck.Where(item => item.Deck.Id == deckId && item.Gamemode.Id == gamemode.getId()).FirstOrDefault();
            _context.GamemodeIncludesDeck.Remove(removeItem);
            _context.SaveChanges();
            return new ReturnObject(true, "deck removed from gamemode");
        }

        public Collection<Gamemode> getGamemodesWhereDeckIsIn(int deckId)
        {
            Collection<GamemodeModel> gamemodes = new Collection<GamemodeModel>();
            foreach (GamemodeIncludesDeck a in _context.GamemodeIncludesDeck.Where(item => item.Deck.Id == deckId))
            {
                gamemodes.Add(a.Gamemode);
            }
            return _gamebridge.mapToGamemodeEntityCollectionFrom(gamemodes);
        }
    }
}
