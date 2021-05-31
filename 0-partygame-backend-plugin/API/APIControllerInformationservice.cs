using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Carddecks;
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

        public APIControllerInformationservice(Informationservice service)
        {
            _informationservice = service;
        }

        [HttpGet("deck")]
        public Task<Collection<Carddeck>> getDecks()
        {
            return Task.FromResult(_carddeckBridge.mapToCarddeckCollectionFrom(_informationservice.getAllDecks()));
        }

        [HttpGet("deck/{deckId}")]
        public Task<Carddeck> getDeck(int deckId)
        {
            return Task.FromResult(_carddeckBridge.mapToCarddeckFrom(_informationservice.getById(deckId)));
        }

        [HttpPost("deck/[action]")]
        public Task<APIReturnObject> addDeck([FromBody] Carddeck deck)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_informationservice.create(deck.Id, deck.Name, _carddeckBridge.mapToCarddeckgenreEntityFrom(deck.Genre))));
        }

        [HttpPut("deck/{deckId}/[action]")]
        public Task<APIReturnObject> updateDeckRating(int deckId, [FromBody] int gamesPlayed, int numberOfRatings, double rating)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_informationservice.updateRating(deckId, rating)));
        }

        [HttpPut("deck/{deckId}/[action]")]
        public Task<APIReturnObject> updateGamesPlayed(int deckId)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_informationservice.updateGamesPlayed(deckId)));
        }

        [HttpPost("deck/{deckId}/[action]")]
        public Task<APIReturnObject> addCardToDeck(int deckId, [FromBody] TaskCard card)
        {
            return Task.FromResult(_returnObjectBridge.mapToAPIReturnObjectFrom(_informationservice.addCard(card)));
        }
    }

}
