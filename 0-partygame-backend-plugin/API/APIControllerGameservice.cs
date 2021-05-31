using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Game;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.GameMappings;
using _1_partygame_backend_adapter.Services;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _0_partygame_backend_plugin.API
{
    [ApiController]
    [Route("api/gameservice/game")]
    public class APIControllerGameservice : ControllerBase
    {

        private readonly Gameservice _gameservice;
        private readonly ReturnObjectBridge _returnObjectBridge = new ReturnObjectBridge();
        private readonly GameBridge _gameBridge = new GameBridge();

        public APIControllerGameservice(Gameservice service)
        {
            _gameservice = service;
        }

        [HttpGet("{gameId}")]
        public Task<GameModel> getGame(int gameId)
        {
            return Task.FromResult(_gameBridge.mapToGameFrom(_gameservice.getById(gameId)));
        }

        [HttpPost]
        public Task<APIReturnObject> createGame([FromBody] GameEntity newGame)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.create(newGame)));
        }

        [HttpGet("{gameId}/player/[action]")]
        public Task<Collection<Player>> getPlayers(int gameId)
        {
            Collection<Player> players = new Collection<Player>();
            foreach(PlayerEntity player in _gameservice.getAllPlayers(gameId))
            {
                players.Add(_gameBridge.mapToPlayerFrom(player));
            }
            return Task.FromResult(players);
        }

        [HttpPost("{gameId}/player/[action]")]
        public Task<APIReturnObject> addPlayer(int gameId, [FromBody] int playerId)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.addPlayer(playerId, gameId)));
        }

        [HttpDelete("{gameId}/player/[action]")]
        public Task<APIReturnObject> removePlayer(int gameId, [FromBody] int playerId)
        {
            return Task.Run(() => _returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.removePlayer(gameId, playerId)));
        }


        [HttpGet("{gameId}/deck/[action]")]
        public Task<Collection<Carddeck>> getDecks(int gameId)
        {
            Collection<Carddeck> decks = new Collection<Carddeck>();
            foreach(CarddeckEntity deck in _gameservice.getDecksForGame(gameId))
            {
                decks.Add(_gameBridge.mapToCarddeckFrom(deck));
            }
            return Task.FromResult(decks);
        }

        [HttpPost("{gameId}/deck/[action]")]
        public Task<APIReturnObject> addDeck(int gameId, [FromBody] int carddeckId)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.addDeck(gameId, carddeckId)));
        }

        [HttpDelete("{gameId}/deck/{deckId}")]
        public Task<APIReturnObject> removeDeck(int gameId, int deckId)
        {
            return Task.Run(() => _returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.removeDeck(gameId, deckId)));
        }


        [HttpPut("{gameId}/status")]
        public Task<APIReturnObject> changeStatus(int gameId, Status status)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.changeStatus(gameId, status)));
        }

        [HttpPut("{gameId}/gamemode")]
        public Task<APIReturnObject> changeGamemode(int gameId, Gamemode gamemode)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.changeGamemode(gameId, gamemode)));
        }


        [HttpPut("{gameId}/card")]
        public Task<APIReturnObject> changeActualCard(int gameId, [FromBody] Taskcard card)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.setActualCard(gameId, _gameBridge.mapToTaskCardFrom(card))));
        }

        [HttpPut("{gameId}/player/[action]")]
        public Task<APIReturnObject> changeActualPlayer(int gameId, [FromBody] int newPlayerId)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.changeActualPlayingUser(newPlayerId, gameId)));
        }

        [HttpPut("{gameId}/executionoftaskrating")]
        public Task<APIReturnObject> addExecutionOftaskRating(int gameId, [FromBody] double rating)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.addExecutionOfTaskRating(gameId, rating)));
        }
    }
}
