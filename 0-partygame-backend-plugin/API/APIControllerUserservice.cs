using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Friends;
using _1_partygame_backend_adapter.APIModels.History;
using _1_partygame_backend_adapter.APIModels.User;
using _1_partygame_backend_adapter.Services;
using _3_partygame_backend_domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _0_partygame_backend_plugin.API
{
    [ApiController]
    [Route("api/userservice/user")]
    public class APIControllerUserservice : ControllerBase
    {
        private readonly Userservice _userservice;

        public APIControllerUserservice(Userservice service)
        {
            _userservice = service;
        }

        [HttpGet("{id}")]
        public Task<UserModel> getUser(int userId)
        {
            return Task.FromResult(_userservice.getUser(userId));
        }

        [HttpPut("{userId}/[action]")]
        public Task<APIReturnObject> changeStatus(int userId, [FromBody] Status status)
        {
            return Task.FromResult(_userservice.changeUserstatus(userId, status));
        }

        [HttpGet("{userId}/history")]
        public Task<HistoryModel> getHistory(int userId)
        {
            return Task.FromResult(_userservice.getHistory(userId));
        }

        [HttpPut("{userId}/history/[action]")]
        public Task<APIReturnObject> updateHistory(int userId, [FromBody] int numberOfPenalties)
        {
            return Task.FromResult(_userservice.updateHistory(userId, numberOfPenalties));
        }

        [HttpGet("{userId}/friend/[action]")]
        public Task<IEnumerable<Friend>> getFriends(int userId)
        {
            return Task.FromResult(_userservice.getFriends(userId));
        }

        [HttpPost("{userId}/friend/[action]")]
        public Task<APIReturnObject> addFriend(int userId, [FromBody] int friendId)
        {
            return Task.FromResult(_userservice.addFriend(userId, friendId));
        }

        [HttpDelete("{userId}/friend/[action]")]
        public Task<APIReturnObject> removeFriend(int userId, [FromBody] int friendId)
        {
            return Task.Run(() => _userservice.removeFriend(userId, friendId));
        }

    }


}
