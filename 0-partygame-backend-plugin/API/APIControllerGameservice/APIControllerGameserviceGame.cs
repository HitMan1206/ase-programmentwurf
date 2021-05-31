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
    public class APIControllerGameserviceGame : ControllerBase
    {

        private readonly Gameservice _gameservice;
        private readonly ReturnObjectBridge _returnObjectBridge = new ReturnObjectBridge();
        private readonly GameBridge _gameBridge = new GameBridge();

        public APIControllerGameserviceGame(Gameservice service)
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

        [HttpPut("{gameId}/status")]
        public Task<APIReturnObject> changeStatus(int gameId, Gamestatus status)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.changeStatus(gameId, _gameBridge.mapToStatusFrom(status))));
        }

        [HttpPut("{gameId}/gamemode")]
        public Task<APIReturnObject> changeGamemode(int gameId, GamemodeModel gamemode)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.changeGamemode(gameId, _gameBridge.mapToGamemodeEntityFrom(gamemode))));
        }


        [HttpPut("{gameId}/card")]
        public Task<APIReturnObject> changeActualCard(int gameId, [FromBody] int cardId)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.setActualCard(gameId, cardId)));
        }


        [HttpPut("{gameId}/executionoftaskrating")]
        public Task<APIReturnObject> addExecutionOftaskRating(int gameId, [FromBody] double rating)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.addExecutionOfTaskRating(gameId, rating)));
        }
    }
}
