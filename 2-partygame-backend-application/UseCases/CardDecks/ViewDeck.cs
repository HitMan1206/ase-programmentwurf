using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _2_partygame_backend_application.UseCases.CardDecks
{
    public class ViewDeck
    {

        private readonly CarddeckRepository carddeckRepository;

        public ViewDeck(CarddeckRepository carddeckRepository)
        {
            this.carddeckRepository = carddeckRepository;
        }

        public Collection<CarddeckEntity> getAllDecks()
        {
            return carddeckRepository.getAllDecks();
        }

        public CarddeckEntity getDeckById(int id)
        {
            return carddeckRepository.getById(id);
        }

        public Collection<TaskCard> getCardsInDeck(CarddeckEntity deck)
        {
            return carddeckRepository.getCardsInDeck(deck);
        } 
        
        public Carddeckgenre getGenre(CarddeckEntity deck)
        {
            return carddeckRepository.getGenre(deck);
        }

        public Collection<Gamemode> getGamemodes()
        {
            return carddeckRepository.getGamemodesWhereDeckIsIn();
        }

    }
}
