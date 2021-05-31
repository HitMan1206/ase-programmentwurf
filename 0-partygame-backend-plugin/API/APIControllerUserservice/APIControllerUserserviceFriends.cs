using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Context;
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

        public APIControllerUserserviceFriends(DatabaseContext context)
        {
            _userservice = new Userservice(context);

            _friendBridge = new FriendBridge();
            _returnBridge = new ReturnObjectBridge();
        }

        [HttpGet("{userId}/friend/[action]")]
        public async Task<ActionResult<Collection<Friend>>> getFriends(int userId)
        {
            if(_userservice.getFriendlist(userId) == null)
            {
                return NotFound("User not found or User has no Friends.");
            }
            return await Task.FromResult(_friendBridge.mapToFriendCollectionFrom(_userservice.getFriendlist(userId)));
        }

        [HttpPost("{userId}/friend/[action]")]
        public async Task<ActionResult<APIReturnObject>> addFriend(int userId, [FromBody] int friendId)
        {
            return await Task.FromResult(_returnBridge.mapToAPIReturnObjectFrom(_userservice.addFriend(userId, friendId)));
        }

        [HttpDelete("{userId}/friend/[action]")]
        public async Task<ActionResult<APIReturnObject>> removeFriend(int userId, [FromBody] int friendId)
        {
            return await Task.Run(() => _returnBridge.mapToAPIReturnObjectFrom(_userservice.deleteFriend(userId, friendId)));
        }
    }
}
