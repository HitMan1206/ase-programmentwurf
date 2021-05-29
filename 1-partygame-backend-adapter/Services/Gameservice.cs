using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Context;
using _1_partygame_backend_adapter.APIModels.Game;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.GameMappings;
using _1_partygame_backend_adapter.Mappings.UserMappings;
using _2_partygame_backend_application.UseCases.Game;
using _2_partygame_backend_application.UseCases.User;
using _3_partygame_backend_domain.AggregateEntities;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.Services
{
    public class Gameservice
    {
        private readonly DatabaseContext _context;
        private readonly GameBridge _bridge;
        private readonly ReturnObjectBridge _returnBridge;
        private readonly ViewGame _viewGame;
        private readonly PlayGame _playGame;
        private readonly ManageGame _manageGame;
        private readonly ViewUser _viewUser;

        public Gameservice(DatabaseContext context, ViewGame viewGame, PlayGame playGame, ManageGame manageGame, ViewUser viewUser)
        {
            _context = context;
            _bridge = new GameBridge();
            _returnBridge = new ReturnObjectBridge();
            _viewGame = viewGame;
            _playGame = playGame;
            _manageGame = manageGame;
            _viewUser = viewUser;
        }

        public GameModel getGame(int id)
        {
            return _context.GameModel.Where(item => item.Id == id).FirstOrDefault();
        }

        public APIReturnObject createGame(GameEntity newGame)
        {
            ReturnObject returnObject = _manageGame.createGame(newGame.Name);
            if (returnObject.isSuccess())
            {
                _context.GameModel.Add(_bridge.mapToGameFrom(newGame));
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }

        public IEnumerable<Player> getPlayers(int gameId)
        {
            return _context.Player.Where(item => item.Game.Id == gameId).ToList();
        }

        public IEnumerable<Carddeck> getDecks(int gameId)
        {
            IEnumerable<GameHasDeck> x = _context.GameHasDeck.Where(item => item.Game.Id == gameId).ToList();
            Collection<Carddeck> decks = new Collection<Carddeck>();
            foreach(GameHasDeck a in x)
            {
                decks.Add(a.Deck);
            }
            return decks;
        }

        public APIReturnObject addPlayer(int gameId, int playerId)
        {
            PlayerEntity newPlayer = new PlayerEntity(_viewGame.getGameById(gameId), _viewUser.getUserById(playerId));
            ReturnObject returnObject = _manageGame.addPlayer(newPlayer);
            if (returnObject.isSuccess())
            {
                _context.Player.Add(_bridge.mapToPlayerFrom(newPlayer));
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }

        public APIReturnObject addDeck(int gameId, int addedDeckId)
        {
            CarddeckEntity addedDeck = _viewGame.getDecksForGame().Where(item => item.getId() == addedDeckId).FirstOrDefault();
            GameHasDeckEntity newGameHasDeck = new GameHasDeckEntity(_viewGame.getGameById(gameId), addedDeck);
            ReturnObject returnObject = _manageGame.addDeck(addedDeck);
            if (returnObject.isSuccess())
            {
                _context.GameHasDeck.Add(_bridge.mapToGameHasDeckFrom(newGameHasDeck));
                _context.SaveChanges();
            }

            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }

        public APIReturnObject changeStatus(int gameId, Status newStatus)
        {
            GameEntity game = _viewGame.getGameById(gameId);
            ReturnObject returnObject = _manageGame.changeStatus(newStatus);
            if (returnObject.isSuccess())
            {
                _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault().Status = _bridge.mapToGamestatusFrom(newStatus);
                _context.Entry(_bridge.mapToGameFrom(game)).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }

        public APIReturnObject changeGamemode(int gameId, Gamemode gamemode)
        {
            GameEntity game = _viewGame.getGameById(gameId);
            ReturnObject returnObject = _manageGame.changeGamemode(gamemode);
            if (returnObject.isSuccess())
            {
                _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault().Gamemode = _bridge.mapToGamemodeFrom(gamemode);
                _context.Entry(_bridge.mapToGameFrom(game)).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }

        public APIReturnObject changeActualCard(int gameId)
        {
            GameEntity game = _viewGame.getGameById(gameId);
            TaskCard newCard = _playGame.drawCard();
            ReturnObject returnObject = _manageGame.changeActualCard(newCard);
            if (returnObject.isSuccess())
            {
                _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault().ActualCard = _bridge.mapToTaskcardFrom(newCard);
                _context.Entry(_bridge.mapToGameFrom(game)).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }

        public APIReturnObject changeActualPlayer(int gameId, int newPlayerId)
        {
            GameEntity game = _viewGame.getGameById(gameId);
            PlayerEntity newPlayer = _playGame.getActualPlayer();
            ReturnObject returnObject = _playGame.changeActualPlayer(newPlayer);
            if (returnObject.isSuccess())
            {
                _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault().ActualPlayer = _bridge.mapToUserFrom(newPlayer.getPlayer());
                _context.Entry(_bridge.mapToGameFrom(game)).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }

        public APIReturnObject changeExecutionOfTaskRating(int gameId, double rating)
        {
            GameEntity game = _viewGame.getGameById(gameId);
            ReturnObject returnObject = _playGame.rateExecutionOfTask(game, rating);
            if (returnObject.isSuccess())
            {

                double newRating;

                double actualRating = (_playGame.getExecutionOfTaskRating(game) * _playGame.getNumberExecutionOfTaskRatings(game));
                int newNumberOfRatings = (_playGame.getNumberExecutionOfTaskRatings(game) + 1);

                newRating = (actualRating + rating) / newNumberOfRatings;

                _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault().ExecutionOfTaskRating = newRating;
                _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault().NumberOfExecutionOfTaskRatings = newNumberOfRatings;
                _context.Entry(_bridge.mapToGameFrom(game)).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }

        public APIReturnObject removePlayer(int gameId, int playerId)
        {
            ReturnObject returnObject = _manageGame.removePlayer(playerId);
            if (returnObject.isSuccess())
            {
                _context.Player.Remove(getPlayers(gameId).Where(item => item.Spieler.Id == playerId).FirstOrDefault());
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }

        public APIReturnObject removeDeck(int gameId, int deckId)
        {
            ReturnObject returnObject = _manageGame.removeDeck(deckId);
            if (returnObject.isSuccess())
            {
                _context.GameHasDeck.Remove(_context.GameHasDeck.Where(item => item.Game.Id == gameId && item.Deck.Id == deckId).FirstOrDefault());
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }
    }
}
