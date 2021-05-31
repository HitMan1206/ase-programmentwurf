using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Context;
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

        public APIControllerGameserviceGame(DatabaseContext context)
        {
            _gameservice = new Gameservice(context);
        }

        [HttpGet("{gameId}")]
        public async Task<ActionResult<GameModel>> getGame(int gameId)
        {
            if(_gameservice.getById(gameId) == null)
            {
                return NotFound("Game not found.");
            }
            return await Task.FromResult(_gameBridge.mapToGameFrom(_gameservice.getById(gameId)));
        }

        [HttpPost]
        public async Task<ActionResult<APIReturnObject>> createGame([FromBody] GameEntity newGame)
        {
            return await Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.create(newGame)));
        }

        [HttpPut("{gameId}/status")]
        public async Task<ActionResult<APIReturnObject>> changeStatus(int gameId, int statusId)
        {
            return await Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.changeStatus(gameId, statusId)));
        }

        [HttpPut("{gameId}/gamemode")]
        public async Task<ActionResult<APIReturnObject>> changeGamemode(int gameId, int gamemodeId)
        {
            return await Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.changeGamemode(gameId, gamemodeId)));
        }


        [HttpPut("{gameId}/card")]
        public async Task<ActionResult<APIReturnObject>> changeActualCard(int gameId, [FromBody] int cardId)
        {
            return await Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.setActualCard(gameId, cardId)));
        }


        [HttpPut("{gameId}/executionoftaskrating")]
        public async Task<ActionResult<APIReturnObject>> addExecutionOftaskRating(int gameId, [FromBody] double rating)
        {
            return await Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.addExecutionOfTaskRating(gameId, rating)));
        }
    }
}
