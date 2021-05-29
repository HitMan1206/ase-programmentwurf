using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.Services;
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

        public APIControllerInformationservice(Informationservice service)
        {
            _informationservice = service;
        }

        [HttpGet("deck")]
        public Task<IEnumerable<Carddeck>> getDecks()
        {
            return Task.FromResult(_informationservice.getDecks());
        }

        [HttpGet("deck/{deckId}")]
        public Task<Carddeck> getDeck(int deckId)
        {
            return Task.FromResult(_informationservice.getDeck(deckId));
        }

        [HttpPut("deck/{deckId}/[action]")]
        public Task<APIReturnObject> addRating(int deckId, [FromBody] double rating)
        {
            return Task.FromResult(_informationservice.addDeckRating(deckId, rating));
        }

        [HttpPost("deck/{deckId}/[action]")]
        public Task<APIReturnObject> addCardToDeck(int deckId, [FromBody] TaskCard card)
        {
            return Task.FromResult(_informationservice.addNewCard(deckId, card));
        }
    }

}
