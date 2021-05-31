using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Repositories
{
    public interface GameRepository
    {
        ReturnObject create(GameEntity game);

        ReturnObject delete(GameEntity game);

        GameEntity getById(int gameId);

        ReturnObject addPlayer(int userId, int gameId);

        ReturnObject removePlayer(int gameId, int playerId);

        Collection<PlayerEntity> getAllPlayers(int gameId);

        ReturnObject changeActualPlayingUser(int playerId, int gameId);

        ReturnObject changeGamemode(int gameId, Gamemode gamemode);

        ReturnObject changeStatus(int gameId, Status status);

        Collection<CarddeckEntity> getDecksForGame(int gameId);

        Collection<TaskCard> getCardsForGame(int gameId);

        ReturnObject removeDeck(int gameId, int deckId);

        ReturnObject addDeck(int gameId, int deckId);

        Collection<GameEntity> getAllGames();

        ReturnObject setActualCard(int gameId, int cardId);

        ReturnObject addExecutionOfTaskRating(int gameId, double rating);

        ReturnObject resetExecutionOfTaskRating(int gameId);


    }
}
