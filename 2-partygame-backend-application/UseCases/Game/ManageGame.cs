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

        public ReturnObject createGame(String name)
        {
            if (viewGame.getAllGames().Where(value => value.Name == name).Count() < 1)
            {
                gameRepository.create(name);
                return new ReturnObject(true, "Game created.");
            }
            else
            {

                return new ReturnObject(false, "Game already exists.");
            }
        }

        public ReturnObject updateGame(GameEntity game)
        {
            gameRepository.update(game);
            return new ReturnObject(true, "Game updated.");
        }

        public ReturnObject closeGame(GameEntity game)
        {
            gameRepository.delete(game);
            return new ReturnObject(true, "Game in Lobby closed.");
        }

        public ReturnObject invitePlayer(FriendEntity friend)
        {
            if(gameRepository.getAllPlayers().Where(value => value.getUserId() == friend.getFriendToId()).Count() < 1)
            {
                gameRepository.invitePlayer(friend);
                return new ReturnObject(true, "Player invited.");
            }
            else
            {
                return new ReturnObject(false, "Friend is already in this Game.");
            }

        }

        public ReturnObject addPlayer(PlayerEntity player)
        {
            if (gameRepository.getAllPlayers().Where(value => value.getUserId() == player.getUserId()).Count() < 1)
            {
                gameRepository.addPlayer(player);
                return new ReturnObject(true, "Player added to Game.");
            }
            else
            {
                return new ReturnObject(false, "Player is already in this Game.");
            }

        }

        public ReturnObject removePlayer(PlayerEntity player)
        {
            if(gameRepository.getAllPlayers().Where(value => value.getUserId() == player.getUserId()).Count() < 1)
            {
                return new ReturnObject(false, "Player does not exist in this Game.");
            }
            else
            {
                gameRepository.removePlayer(player);
                return new ReturnObject(true, "Player removed.");
            }
        }

        public ReturnObject changeGamemode(Gamemode mode)
        {
            gameRepository.changeGamemode(mode);
            return new ReturnObject(true, "Gamemode changed.");
        }

        public ReturnObject removeDeck(CarddeckEntity deck)
        {
            if (gameRepository.getDecksForGame().Where(value => value.getId() == deck.getId()).Count() < 1)
            {
                return new ReturnObject(false, "Deck does not exist in this Game.");
            }
            else
            {
                gameRepository.removeDeck(deck);
                return new ReturnObject(true, "Deck removed.");
            }
        }

        public ReturnObject removeAllDecksFromGame(GameEntity game)
        {
            gameRepository.removeAllDecksFromGame(game);
            return new ReturnObject(true, "All Decks removed.");
        }

        public ReturnObject addDeck(CarddeckEntity deck)
        {
            if (gameRepository.getDecksForGame().Where(value => value.getId() == deck.getId()).Count() < 1)
            {
                gameRepository.addDeck(deck);
                return new ReturnObject(true, "Deck geadded.");
            }
            else
            {
                return new ReturnObject(false, "Deck is already in this Game.");
            }
        }
    }
}
