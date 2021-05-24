using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Repositories
{
    interface GameRepository
    {
        bool create(String name);

        bool update(GameEntity game);

        GameEntity getById(int gameId);

        bool invitePlayer(FriendEntity friend);

        bool removePlayer(PlayerEntity player);

        bool changeGamemode(Gamemode gamemode);

        Collection<CarddeckEntity> getDecks();

        bool removeDeck(CarddeckEntity deck);

        bool addDeck(CarddeckEntity deck);


    }
}
