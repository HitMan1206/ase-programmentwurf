using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Context;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.CarddeckMappings;
using _1_partygame_backend_adapter.Services;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _0_partygame_backend_plugin.API
{

    [ApiController]
    [Route("api/informationservice")]
    public class APIControllerInformationservice : ControllerBase
    {

        private readonly Informationservice _informationservice;
        private readonly CarddeckBridge _carddeckBridge = new CarddeckBridge();
        private readonly ReturnObjectBridge _returnObjectBridge = new ReturnObjectBridge();

        public APIControllerInformationservice(DatabaseContext context)
        {
            _informationservice = new Informationservice(context);
        }

        [HttpGet("deck")]
        public async Task<ActionResult<Collection<Carddeck>>> getDecks()
        {
            if(_informationservice.getAllDecks() == null || _informationservice.getAllDecks().Count < 1)
            {
                return NotFound("No Decks available.");
            }
            return await Task.FromResult(_carddeckBridge.mapToCarddeckCollectionFrom(_informationservice.getAllDecks()));
        }

        [HttpGet("deck/{deckId}")]
        public async Task<ActionResult<Carddeck>> getDeck(int deckId)
        {
            if(_informationservice.getById(deckId) == null)
            {
                return NotFound("Deck not found.");
            }
            return await Task.FromResult(_carddeckBridge.mapToCarddeckFrom(_informationservice.getById(deckId)));
        }

        [HttpPost("deck/[action]")]
        public async Task<ActionResult<APIReturnObject>> addDeck([FromBody] Carddeck deck)
        {
            return await Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_informationservice.create(deck.Id, deck.Name, deck.GenreId)));
        }

        [HttpPut("deck/{deckId}/[action]")]
        public async Task<ActionResult<APIReturnObject>> updateDeckRating(int deckId, [FromBody] int gamesPlayed, int numberOfRatings, double rating)
        {
            return await Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_informationservice.updateRating(deckId, rating)));
        }

        [HttpPut("deck/{deckId}/[action]")]
        public async Task<ActionResult<APIReturnObject>> updateGamesPlayed(int deckId)
        {
            return await Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_informationservice.updateGamesPlayed(deckId)));
        }

        [HttpPost("deck/{deckId}/[action]")]
        public async Task<ActionResult<APIReturnObject>> addCardToDeck(int deckId, [FromBody] TaskCard card)
        {
            return await Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_informationservice.addCard(card)));
        }
    }

}
