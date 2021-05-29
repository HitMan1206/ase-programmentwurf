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
        ReturnObject create(String name);

        ReturnObject delete(GameEntity game);

        GameEntity getById(int gameId);

        ReturnObject invitePlayer(FriendEntity friend);

        ReturnObject addPlayer(PlayerEntity player);

        ReturnObject removePlayer(int playerId);

        Collection<PlayerEntity> getAllPlayers();

        PlayerEntity getActualPlayingUser();

        ReturnObject changeActualPlayingUser(PlayerEntity player);

        ReturnObject changeGamemode(Gamemode gamemode);

        ReturnObject changeStatus(Status status);

        Collection<CarddeckEntity> getDecksForGame();

        Collection<TaskCard> getCardsForGame();

        ReturnObject removeDeck(int deckId);

        ReturnObject removeAllDecksFromGame(GameEntity game);

        ReturnObject addDeck(CarddeckEntity deck);

        Collection<GameEntity> getAllGames();

        TaskCard getActualCard(GameEntity game);

        ReturnObject setActualCard(TaskCard card);

        ReturnObject updateExecutionOfTaskRating(double rating, int numberOfRatings);

        ReturnObject resetExecutionOfTaskRating();

        double getExecutionOfTaskRating(GameEntity game);

        int getNumberOfExecutionOfTaskRatings(GameEntity game);


    }
}
