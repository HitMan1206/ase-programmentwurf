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
using _3_partygame_backend_domain.Repositories;
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
    public class Gameservice: GameRepository
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

        public ReturnObject addDeck(int gameId, int deckId)
        {
            var game = _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault();
            var deck = _context.Carddeck.Where(item => item.Id == deckId).FirstOrDefault();

            _context.GameHasDeck.Add(new GameHasDeck(game, deck));
            _context.SaveChanges();

            return new ReturnObject(true, "deck added to game");
        }

        public ReturnObject addPlayer(int userId, int gameId)
        {
            var game = _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault();
            var user = _context.UserModel.Where(item => item.Id == userId).FirstOrDefault();

            _context.Player.Add(new Player(user, game));
            _context.SaveChanges();

            return new ReturnObject(true, "player added to game");
        }

        public ReturnObject changeActualPlayingUser(int playerId, int gameId)
        {
            var game = _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault();
            var player = _context.UserModel.Where(item => item.Id == playerId).FirstOrDefault();

            game.ActualPlayer = player;
            _context.SaveChanges();

            return new ReturnObject(true, "actual playing user changed");
        }

        public ReturnObject changeGamemode(int gameId, Gamemode gamemode)
        {
            var game = _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault();

            game.Gamemode = _bridge.mapToGamemodeFrom(gamemode);
            _context.SaveChanges();

            return new ReturnObject(true, "gamemode changed");
        }

        public ReturnObject changeStatus(int gameId, Status status)
        {
            var game = _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault();

            game.Status = _bridge.mapToGamestatusFrom(status);
            _context.SaveChanges();

            return new ReturnObject(true, "status changed");
        }

        public ReturnObject create(GameEntity game)
        {
            _context.GameModel.Add(_bridge.mapToGameFrom(game));
            _context.SaveChanges();

            return new ReturnObject(true, "game created");
        }

        public ReturnObject delete(GameEntity game)
        {
            _context.GameModel.Remove(_bridge.mapToGameFrom(game));
            _context.SaveChanges();

            return new ReturnObject(true, "game deleted");
        }

        public Collection<GameEntity> getAllGames()
        {
            var games = _context.GameModel;
            Collection<GameEntity> allGames = new Collection<GameEntity>();
            foreach(GameModel a in games)
            {
                allGames.Add(_bridge.mapToGameEntityFrom(a));
            }
            return allGames;
        }

        public Collection<PlayerEntity> getAllPlayers(int gameId)
        {
            var players = _context.Player.Where(item => item.Game.Id == gameId);
            Collection<PlayerEntity> allPlayers = new Collection<PlayerEntity>();
            foreach (Player a in players)
            {
                allPlayers.Add(_bridge.mapToPlayerEntityFrom(a));
            }
            return allPlayers;
        }

        public GameEntity getById(int gameId)
        {
            return _bridge.mapToGameEntityFrom(_context.GameModel.Where(item => item.Id == gameId).FirstOrDefault());
        }

        public Collection<TaskCard> getCardsForGame(int gameId)
        {
            var decks = _context.GameHasDeck.Where(item => item.Game.Id == gameId);
            var cards = new Collection<TaskCard>();
            foreach(GameHasDeck deck in decks)
            {
                var cardsindeck = _context.DeckIncludesCard.Where(item => item.Deck.Id == deck.Deck.Id);
                foreach(DeckIncludesCard card in cardsindeck)
                {
                    cards.Add(_bridge.mapToTaskCardFrom(card.Card));
                }
            }
            return cards;
        }

        public Collection<CarddeckEntity> getDecksForGame(int gameId)
        {
            var decksingame = _context.GameHasDeck.Where(item => item.Game.Id == gameId);
            var decks = new Collection<CarddeckEntity>();
            foreach (GameHasDeck deck in decksingame)
            {
                decks.Add(_bridge.mapToCarddeckEntityFrom(deck.Deck));
            }
            return decks;
        }

        public ReturnObject removeDeck(int gameId, int deckId)
        {
            var deck = _context.GameHasDeck.Where(item => item.Game.Id == gameId && item.Deck.Id == deckId).FirstOrDefault();
            _context.GameHasDeck.Remove(deck);
            _context.SaveChanges();
            return new ReturnObject(true, "deck removed from game");
        }

        public ReturnObject removePlayer(int gameId, int playerId)
        {
            var player = _context.Player.Where(item => item.Game.Id == gameId && item.Spieler.Id == playerId).FirstOrDefault();
            _context.Player.Remove(player);
            _context.SaveChanges();

            return new ReturnObject(true, "deck removed from game");
        }

        public ReturnObject resetExecutionOfTaskRating(int gameId)
        {
            var game = _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault();
            game.NumberOfExecutionOfTaskRatings = 0;
            game.ExecutionOfTaskRating = 0.0;
            _context.SaveChanges();
            return new ReturnObject(true, "execution of task rating resetted");
        }

        public ReturnObject setActualCard(int gameId, TaskCard card)
        {
            var game = _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault();
            game.ActualCard = _bridge.mapToTaskcardFrom(card);
            _context.SaveChanges();
            return new ReturnObject(true, "actual card changed");
        }

        public ReturnObject addExecutionOfTaskRating(int gameId, double rating)
        {
            var game = _context.GameModel.Where(item => item.Id == gameId).FirstOrDefault();
            var oldRating = game.ExecutionOfTaskRating;
            var oldNumberOfRatings = game.NumberOfExecutionOfTaskRatings;

            var newRating = (((oldRating * oldNumberOfRatings) + rating) / (oldNumberOfRatings + 1));

            game.ExecutionOfTaskRating = newRating;
            game.NumberOfExecutionOfTaskRatings = oldNumberOfRatings + 1;

            _context.SaveChanges();

            return new ReturnObject(true, "execution of task rating updated");
        }

        /* public APIReturnObject createGame(GameEntity newGame)
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
         }*/

    }
}
