using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Friends;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.FriendMappings;
using _1_partygame_backend_adapter.Mappings.UserMappings;
using _1_partygame_backend_adapter.Services;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _0_partygame_backend_plugin.API.APIControllerUserservice
{
    [Route("api/userservice/user")]
    [ApiController]
    public class APIControllerUserserviceFriends : ControllerBase
    {

        private readonly Userservice _userservice;
        private readonly ReturnObjectBridge _returnBridge;
        private readonly FriendBridge _friendBridge;

        public APIControllerUserserviceFriends(Userservice service)
        {
            _userservice = service;

            _friendBridge = new FriendBridge();
            _returnBridge = new ReturnObjectBridge();
        }

        [HttpGet("{userId}/friend/[action]")]
        public Task<Collection<Friend>> getFriends(int userId)
        {
            var friends = _userservice.getFriendlist(userId);
            Collection<Friend> x = new Collection<Friend>();
            foreach (FriendEntity a in friends)
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
