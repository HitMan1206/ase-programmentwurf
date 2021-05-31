using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2_partygame_backend_application.UseCases.Game
{
    public class ManageGame
    {
        private readonly GameRepository gameRepository;
        private readonly ViewGame viewGame;

        public ManageGame(GameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
            this.viewGame = new ViewGame(gameRepository);
        }

        public ReturnObject createGame(GameEntity game)
        {
            if (viewGame.getAllGames().Where(value => value.getId() == game.getId()).Count() < 1)
            {
                gameRepository.create(game);
                return new ReturnObject(true, "Game created.");
            }
            else
            {

                return new ReturnObject(false, "Game already exists.");
            }
        }

        public ReturnObject changeStatus(int gameId, Status status)
        {
            gameRepository.changeStatus(gameId, status.getId());
            return new ReturnObject(true, "Status updated.");
        }

        public ReturnObject changeActualCard(int gameId, int cardId)
        {
            gameRepository.setActualCard(gameId, cardId);
            return new ReturnObject(true, "Actual Card updated.");
        }

        public ReturnObject closeGame(GameEntity game)
        {
            gameRepository.delete(game);
            return new ReturnObject(true, "Game in Lobby closed.");
        }

        public ReturnObject addPlayer(int gameId, int playerId)
        {
            if (gameRepository.getAllPlayers(gameId).Where(value => value.getUserId() == playerId).Count() < 1)
            {
                gameRepository.addPlayer(playerId, gameId);
                return new ReturnObject(true, "Player added to Game.");
            }
            else
            {
                return new ReturnObject(false, "Player is already in this Game.");
            }

        }

        public ReturnObject removePlayer(int gameId, int playerId)
        {
            if(gameRepository.getAllPlayers(gameId).Where(value => value.getUserId() == playerId).Count() < 1)
            {
                return new ReturnObject(false, "Player does not exist in this Game.");
            }
            else
            {
                gameRepository.removePlayer(gameId, playerId);
                return new ReturnObject(true, "Player removed.");
            }
        }

        public ReturnObject changeGamemode(int gameId, Gamemode mode)
        {
            gameRepository.changeGamemode(gameId, mode.getId());
            return new ReturnObject(true, "Gamemode changed.");
        }

        public ReturnObject removeDeck(int gameId, int deckId)
        {
            if (gameRepository.getDecksForGame(gameId).Where(value => value.getId() == deckId).Count() < 1)
            {
                return new ReturnObject(false, "Deck does not exist in this Game.");
            }
            else
            {
                gameRepository.removeDeck(gameId, deckId);
                return new ReturnObject(true, "Deck removed.");
            }
        }

        public ReturnObject addDeck(int gameId, int deckId)
        {
            if (gameRepository.getDecksForGame(gameId).Where(value => value.getId() == deckId).Count() < 1)
            {
                gameRepository.addDeck(gameId, deckId);
                return new ReturnObject(true, "Deck geadded.");
            }
            else
            {
                return new ReturnObject(false, "Deck is already in this Game.");
            }
        }
    }
}
