using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Context;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.CarddeckMappings;
using _1_partygame_backend_adapter.Mappings.GameMappings;
using _1_partygame_backend_adapter.Services;
using _3_partygame_backend_domain.Entities;
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
    public class APIControllerGameserviceDeck : ControllerBase
    {

        private readonly Gameservice _gameservice;
        private readonly ReturnObjectBridge _returnObjectBridge = new ReturnObjectBridge();
        private readonly GameBridge _gameBridge = new GameBridge();
        private readonly CarddeckBridge _carddeckBridge = new CarddeckBridge();

        public APIControllerGameserviceDeck(DatabaseContext context)
        {
            _gameservice = new Gameservice(context);
        }

        [HttpGet("{gameId}/deck/[action]")]
        public async Task<ActionResult<Collection<Carddeck>>> getDecks(int gameId)
        {
            Collection<CarddeckEntity> decks = _gameservice.getDecksForGame(gameId);
            if(decks == null || decks.Count < 1)
            {
                return NotFound("No decks in Game or Deck not found");
            }
            return await Task.FromResult(_carddeckBridge.mapToCarddeckCollectionFrom(decks));
        }

        [HttpPost("{gameId}/deck/[action]")]
        public async Task<ActionResult<APIReturnObject>> addDeck(int gameId, [FromBody] int carddeckId)
        {
            return await Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.addDeck(gameId, carddeckId)));
        }

        [HttpDelete("{gameId}/deck/{deckId}")]
        public async Task<ActionResult<APIReturnObject>> removeDeck(int gameId, int deckId)
        {
            return await Task.Run(() => _returnObjectBridge.mapToAPIReturnObjectFrom(_gameservice.removeDeck(gameId, deckId)));
        }
    }
}
