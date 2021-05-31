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
        ReturnObject create(int id, String name, int genre);

        ReturnObject updateGamesPlayed(int deckId);

        ReturnObject updateRating(int deckId, double rating);

        ReturnObject addCard(TaskCard card);

        CarddeckEntity getById(int deckId);

        Collection<CarddeckEntity> getAllDecks();

        Collection<TaskCard> getCardsInDeck(CarddeckEntity deck);

        ReturnObject addToGamemode(int deckId, Gamemode gamemode);

        ReturnObject removeFromGameode(int deckId, Gamemode gamemode);

        Collection<Gamemode> getGamemodesWhereDeckIsIn(int deckId);

    }
}
