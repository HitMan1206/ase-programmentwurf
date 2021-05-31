using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _2_partygame_backend_applicationTests.Mocks
{
    class GameRepositoryMock : GameRepository
    {
        public ReturnObject addDeck(CarddeckEntity deck)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject addDeck(int gameId, int deckId)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject addExecutionOfTaskRating(int gameId, double rating)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject addPlayer(int userId, int gameId)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject changeActualPlayingUser(int playerId, int gameId)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject changeGamemode(int gameId, int gamemodeId)
        {
            return new ReturnObject(true, "Test");
        }


        public ReturnObject changeStatus(int gameId, int statusId)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject create(GameEntity game)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject delete(GameEntity game)
        {
            return new ReturnObject(true, "Test");
        }

        public TaskCard getActualCard(GameEntity game)
        {
            return new TaskCard(0, "Test", "Test", "Test");
        }

        public PlayerEntity getActualPlayingUser()
        {
            return new PlayerEntity(0, 0);
        }

        public Collection<GameEntity> getAllGames()
        {
            return new Collection<GameEntity>();
        }

        public Collection<PlayerEntity> getAllPlayers(int gameId)
        {
            return new Collection<PlayerEntity>();
        }

        public GameEntity getById(int gameId)
        {
            return new GameEntity(0, "Test");
        }

        public Collection<TaskCard> getCardsForGame(int gameId)
        {
            return new Collection<TaskCard>();
        }

        public Collection<CarddeckEntity> getDecksForGame()
        {
            return new Collection<CarddeckEntity>();
        }

        public Collection<CarddeckEntity> getDecksForGame(int gameId)
        {
            return new Collection<CarddeckEntity>();
        }

        public double getExecutionOfTaskRating(GameEntity game)
        {
            return 0.0;
        }

        public int getNumberOfExecutionOfTaskRatings(GameEntity game)
        {
            return 5;
        }

        public ReturnObject invitePlayer(FriendEntity friend)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject removeAllDecksFromGame(GameEntity game)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject removeDeck(int gameId, int deckId)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject removePlayer(int gameId, int playerId)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject resetExecutionOfTaskRating(int gameId)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject setActualCard(int gameId, int cardId)
        {
            return new ReturnObject(true, "Test");
        }

        public ReturnObject updateExecutionOfTaskRating(double rating, int numberOfRatings)
        {
            return new ReturnObject(true, "Test");
        }
    }
}
