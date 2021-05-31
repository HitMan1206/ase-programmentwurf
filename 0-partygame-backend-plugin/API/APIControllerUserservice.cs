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
using _3_partygame_backend_domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _0_partygame_backend_plugin.API
{
    [ApiController]
    [Route("api/userservice/user")]
    public class APIControllerUserservice : Controller
    {
        private readonly Userservice _userservice;
        private readonly UserBridge _userBridge;
        private readonly ReturnObjectBridge _returnBridge;
        private readonly FriendBridge _friendBridge;

        public APIControllerUserservice(Userservice service)
        {
            _userservice = service;

            _friendBridge = new FriendBridge();
            _userBridge = new UserBridge();
            _returnBridge = new ReturnObjectBridge();
        }

       [HttpPost]
        public Task<APIReturnObject> AddUser(UserModel user)
        {
            return Task.FromResult(_returnBridge.mapToAPIReturnObjectFrom(_userservice.create(user.Id, user.Username, user.Email, user.Password)));
        }

        [HttpGet("{userId}")]
        public Task<UserModel> GetUser(int userId)
        {
            return Task.FromResult(_userBridge.mapToUserFrom(_userservice.findById(userId)));
        }

        [HttpPut("{userId}/[action]")]
        public Task<APIReturnObject> changeStatus(int userId, [FromBody] Status status)
        {
            return Task.FromResult(_returnBridge.mapToAPIReturnObjectFrom(_userservice.changeStatus(userId, status)));
        }

        [HttpGet("{userId}/history")]
        public Task<HistoryModel> getHistory(int userId)
        {
            return Task.FromResult(_userBridge.mapToHistoryFrom(_userservice.getHistory(userId)));
        }

        [HttpPut("{userId}/history/[action]")]
        public Task<APIReturnObject> updateHistory(int userId, [FromBody] HistoryEntity history)
        {
            return Task.FromResult(_returnBridge.mapToAPIReturnObjectFrom(_userservice.updateHistory(userId, history)));
        }

        [HttpGet("{userId}/friend/[action]")]
        public Task<Collection<Friend>> getFriends(int userId)
        {
            var friends = _userservice.getFriendlist(userId);
            Collection<Friend> x = new Collection<Friend>();
            foreach(FriendEntity a in friends)
            {
                x.Add(_friendBridge.mapToFriendFrom(a));
            }

            return Task.FromResult(x);
        }

        [HttpPost("{userId}/friend/[action]")]
        public Task<APIReturnObject> addFriend(int userId, [FromBody] int friendId)
        {
            return Task.FromResult(_returnBridge.mapToAPIReturnObjectFrom(_userservice.addFriend(userId, friendId)));
        }

        [HttpDelete("{userId}/friend/[action]")]
        public Task<APIReturnObject> removeFriend(int userId, [FromBody] int friendId)
        {
            return Task.Run(() => _returnBridge.mapToAPIReturnObjectFrom(_userservice.deleteFriend(userId, friendId)));
        }
    }


}
