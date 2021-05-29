using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Repositories
{
    public interface CarddeckRepository
    {
        ReturnObject create(String name, Carddeckgenre genre);

        ReturnObject update(CarddeckEntity deck);

        ReturnObject rate(CarddeckEntity deck, double rating);

        ReturnObject addCard(TaskCard card);

        CarddeckEntity getById(int deckId);

        Collection<CarddeckEntity> getAllDecks();

        Carddeckgenre getGenre(CarddeckEntity deck);

        Collection<TaskCard> getCardsInDeck(CarddeckEntity deck);

        ReturnObject addToGamemode(Gamemode gamemode);

        ReturnObject removeFromGameode(Gamemode gamemode);

        Collection<Gamemode> getGamemodesWhereDeckIsIn();

    }
}
