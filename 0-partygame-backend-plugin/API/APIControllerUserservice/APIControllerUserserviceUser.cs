using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Context;
using _1_partygame_backend_adapter.APIModels.Friends;
using _1_partygame_backend_adapter.APIModels.History;
using _1_partygame_backend_adapter.APIModels.User;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.FriendMappings;
using _1_partygame_backend_adapter.Mappings.UserMappings;
using _1_partygame_backend_adapter.Services;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _0_partygame_backend_plugin.API
{
    [ApiController]
    [Route("api/userservice/user")]
    public class APIControllerUserserviceUser : ControllerBase
    {
        private readonly Userservice _userservice;
        private readonly UserBridge _userBridge;
        private readonly ReturnObjectBridge _returnBridge;

        public APIControllerUserserviceUser(DatabaseContext context)
        {
            _userservice = new Userservice(context);

            _userBridge = new UserBridge();
            _returnBridge = new ReturnObjectBridge();
        }

       [HttpPost]
        public async Task<ActionResult<APIReturnObject>> AddUser([FromBody] UserModel user)
        {
            return await Task.FromResult(_returnBridge.mapToAPIReturnObjectFrom(_userservice.create(user.Id, user.Username, user.Email, user.Password)));
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserModel>> GetUser(int userId)
        {
            if(_userservice.findById(userId) == null)
            {
                return NotFound("User not Found.");
            }
            return await Task.FromResult(_userBridge.mapToUserFrom(_userservice.findById(userId)));
        }

        [HttpPut("{userId}/[action]")]
        public async Task<ActionResult<APIReturnObject>> changeStatus(int userId, [FromBody] int statusId)
        {
            return await Task.FromResult(_returnBridge.mapToAPIReturnObjectFrom(_userservice.changeStatus(userId, statusId)));
        }
    }


}
