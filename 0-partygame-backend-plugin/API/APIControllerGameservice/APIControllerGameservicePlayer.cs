using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Game;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.GameMappings;
using _1_partygame_backend_adapter.Services;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _0_partygame_backend_plugin.API.APIControllerGameservice
{
    [Route("api/gameservice/game")]
    [ApiController]
    public class APIControllerGameservicePlayer : ControllerBase
    {

        private readonly Gameservice _gameservice;
        private readonly ReturnObjectBridge _returnObjectBridge = new ReturnObjectBridge();
        private readonly GameBridge _gameBridge = new GameBridge();

        public APIControllerGameservicePlayer(Gameservice service)
        {
            _gameservice = service;
        }

        [HttpGet("{gameId}/player/[action]")]
        public Task<Collection<Player>> getPlayers(int gameId)
        {
            Collection<PlayerEntity> players = _gameservice.getAllPlayers(gameId);
            return Task.FromResult(_gameBridge.mapToPlayerCollectionFrom(players));
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

        [HttpPut("{gameId}/player/[action]")]
        public Task<APIReturnObject> changeActualPlayer(int gameId, [FromBody] int newPlayerId)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.changeActualPlayingUser(newPlayerId, gameId)));
        }
    }
}
