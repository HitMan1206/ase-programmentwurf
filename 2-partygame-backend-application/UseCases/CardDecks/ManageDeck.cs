using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2_partygame_backend_application.UseCases.CardDecks
{
    public class ManageDeck
    {
        private readonly CarddeckRepository carddeckRepository;
        private readonly ViewDeck viewDeck;

        public ManageDeck(CarddeckRepository carddeckRepository)
        {
            this.carddeckRepository = carddeckRepository;
            this.viewDeck = new ViewDeck(carddeckRepository);
        }


        public ReturnObject rateDeck(CarddeckEntity deck)
        {
            try
            {
                carddeckRepository.update(deck);
                return new ReturnObject (true, "Deck rated.");
            }catch(Exception e)
            {
                return new ReturnObject(false, e.Message);
            }
        }
        
        public ReturnObject createDeck(int id, String name, Carddeckgenre genre)
        {
            if (viewDeck.getAllDecks().Where(value => value.getName() == name).Count() < 1)
            {
                carddeckRepository.create(id, name, genre);
                return new ReturnObject(true, "Deck created.");
            }
            else
            {
                return new ReturnObject(false, "Deck already exists.");
            }
        }

        public ReturnObject updateDeck(CarddeckEntity deck)
        {
            try
            {
                carddeckRepository.update(deck);
                return new ReturnObject(true, "Deck updated.");
            }
            catch(Exception e)
            {
                return new ReturnObject(false, e.Message);
            }
        }

        public ReturnObject addToGamemode(int deckId, Gamemode mode)
        {
            if (viewDeck.getGamemodes(deckId).Contains(mode))
            {
                return new ReturnObject(false, "Deck is already in Gamemode.");
            }
            else
            {
                carddeckRepository.addToGamemode(deckId, mode);
                return new ReturnObject(true, "Deck added to Gamemode.");
            }
        }

        public ReturnObject removeFromGamemode(int deckId, Gamemode mode)
        {
            if (viewDeck.getGamemodes(deckId).Contains(mode))
            {
                carddeckRepository.removeFromGameode(deckId, mode);
                return new ReturnObject(true, "Deck removed from Gamemode.");
            }
            else
            {
                return new ReturnObject(false, "Deck does not exist in this Gamemode.");
            }
        }
    }
}
