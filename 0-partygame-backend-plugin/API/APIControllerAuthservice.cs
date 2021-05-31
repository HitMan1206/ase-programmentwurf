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

        public APIControllerAuthservice(DatabaseContext context)
        {
            _authservice = Authservice.getInstance(context);
        }

        [HttpPost("login")]
        public async Task<ActionResult<APIReturnObject>> Login([FromBody] string email, string password)
        {
            return await Task.FromResult(_authservice.login(email, password));
        }

        [HttpPost("register")]
        public async Task<ActionResult<APIReturnObject>> Register([FromBody] UserModel user)
        {

            return await Task.FromResult(_authservice.register(user.Id, user.Email, user.Username, user.Password));
        }

    }
}
