using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Context;
using _1_partygame_backend_adapter.APIModels.Game;
using _1_partygame_backend_adapter.APIModels.History;
using _1_partygame_backend_adapter.APIModels.User;
using _1_partygame_backend_adapter.Mappings.GameMappings;
using _1_partygame_backend_adapter.Services;
using _2_partygame_backend_application.UseCases.Game;
using _3_partygame_backend_domain.Services.auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _0_partygame_backend_plugin.API
{
    [Route("api/authservice")]
    [ApiController]
    public class APIControllerAuthservice : ControllerBase
    {
        private readonly Authservice _authservice;

        public APIControllerAuthservice(Authservice authservice)
        {
            _authservice = authservice;
        }

        [HttpPost("login")]
        public Task<APIReturnObject> login([FromBody] string email, string password)
        {
            return Task.FromResult(_authservice.login(email, password));
        }

        [HttpPost("register")]
        public Task<APIReturnObject> register([FromBody] string email, string password, string username)
        {

            return Task.FromResult(_authservice.register(email, username, password));
        }

    }
}
