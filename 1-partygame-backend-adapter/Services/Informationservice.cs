using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Context;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.CarddeckMappings;
using _2_partygame_backend_application.UseCases.CardDecks;
using _3_partygame_backend_domain.AggregateEntities;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.Services
{
    public class Informationservice
    {
        private readonly DatabaseContext _context;
        private readonly CarddeckBridge _bridge;
        private readonly ReturnObjectBridge _returnBridge;
        private readonly AddNewCard _addNewCard;
        private readonly ManageDeck _manageDeck;
        private readonly ViewDeck _viewDeck;

        public Informationservice(DatabaseContext context, AddNewCard addNewCard, ManageDeck manageDeck, ViewDeck viewDeck)
        {
            _context = context;
            _bridge = new CarddeckBridge();
            _returnBridge = new ReturnObjectBridge();
            _addNewCard = addNewCard;
            _manageDeck = manageDeck;
            _viewDeck = viewDeck;
        }

        public Carddeck getDeck(int deckId)
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
    }
}
