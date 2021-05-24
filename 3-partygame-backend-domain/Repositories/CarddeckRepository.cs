using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Repositories
{
    interface CarddeckRepository
    {
        bool create(String name, Carddeckgenre genre);

        bool update(CarddeckEntity deck);

        bool rate(CarddeckEntity deck, int rating);

        bool addCard(TaskCard card);

        CarddeckEntity getById(int deckId);

        Carddeckgenre getGenre(CarddeckEntity deck);

        Collection<TaskCard> getCardsInDeck();

        bool addToGamemode(Gamemode gamemode);

        bool removeFromGameode(Gamemode gamemode);

        Collection<Gamemode> getGamemodesWhereDeckIsIn();

    }
}
