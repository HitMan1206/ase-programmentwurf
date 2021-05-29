using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Game;
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

        public APIControllerGameservice(Gameservice service)
        {
            _gameservice = service;
        }

        [HttpGet("{gameId}")]
        public Task<GameModel> getGame(int gameId)
        {
            return Task.FromResult(_gameservice.getGame(gameId));
        }

        [HttpPost]
        public Task<APIReturnObject> createGame([FromBody] GameEntity newGame)
        {
            return Task.FromResult(_gameservice.createGame(newGame));
        }

        [HttpGet("{gameId}/player/[action]")]
        public Task<IEnumerable<Player>> getPlayers(int gameId)
        {
            return Task.FromResult(_gameservice.getPlayers(gameId));
        }

        [HttpPost("{gameId}/player/[action]")]
        public Task<APIReturnObject> addPlayer(int gameId, [FromBody] int playerId)
        {
            return Task.FromResult(_gameservice.addPlayer(gameId, playerId));
        }

        [HttpDelete("{gameId}/player/[action]")]
        public Task<APIReturnObject> removePlayer(int gameId, [FromBody] int playerId)
        {
            return Task.Run(() => _gameservice.removePlayer(gameId, playerId));
        }


        [HttpGet("{gameId}/deck/[action]")]
        public Task<IEnumerable<Carddeck>> getDecks(int gameId)
        {
            return Task.FromResult(_gameservice.getDecks(gameId));
        }

        [HttpPost("{gameId}/deck/[action]")]
        public Task<APIReturnObject> addDeck(int gameId, [FromBody] int carddeckId)
        {
            return Task.FromResult(_gameservice.addDeck(gameId, carddeckId));
        }

        [HttpDelete("{gameId}/deck/{deckId}")]
        public Task<APIReturnObject> removeDeck(int gameId, int deckId)
        {
            return Task.Run(() => _gameservice.removeDeck(gameId, deckId));
        }


        [HttpPut("{gameId}/status")]
        public Task<APIReturnObject> changeStatus(int gameId, Status status)
        {
            return Task.FromResult(_gameservice.changeStatus(gameId, status));
        }

        [HttpPut("{gameId}/gamemode")]
        public Task<APIReturnObject> changeGamemode(int gameId, Gamemode gamemode)
        {
            return Task.FromResult(_gameservice.changeGamemode(gameId, gamemode));
        }


        [HttpPut("{gameId}/card")]
        public Task<APIReturnObject> changeActualCard(int gameId)
        {
            return Task.FromResult(_gameservice.changeActualCard(gameId));
        }

        [HttpPut("{gameId}/player/[action]")]
        public Task<APIReturnObject> changeActualPlayer(int gameId, [FromBody] int newPlayerId)
        {
            return Task.FromResult(_gameservice.changeActualPlayer(gameId, newPlayerId));
        }

        [HttpPut("{gameId}/executionoftaskrating")]
        public Task<APIReturnObject> changeExecutionOftaskRating(int gameId, [FromBody] double rating)
        {
            return Task.FromResult(_gameservice.changeExecutionOfTaskRating(gameId, rating));
        }
    }
}
