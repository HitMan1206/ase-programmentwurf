using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Context;
using _1_partygame_backend_adapter.APIModels.History;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.FriendMappings;
using _1_partygame_backend_adapter.Mappings.UserMappings;
using _1_partygame_backend_adapter.Services;
using _3_partygame_backend_domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0_partygame_backend_plugin.API.APIControllerUserservice
{
    [Route("api/userservice/user")]
    [ApiController]
    public class APIControllerUserserviceHistory : ControllerBase
    {

        private readonly Userservice _userservice;
        private readonly UserBridge _userBridge;
        private readonly ReturnObjectBridge _returnBridge;

        public APIControllerUserserviceHistory(DatabaseContext context)
        {
            _userservice = new Userservice(context);

            _userBridge = new UserBridge();
            _returnBridge = new ReturnObjectBridge();
        }

        [HttpGet("{userId}/history")]
        public async Task<ActionResult<HistoryModel>> getHistory(int userId)
        {
            if(_userservice.getHistory(userId) == null){
                return NotFound("User has no History or User not found.");
            }
            return await Task.FromResult(_userBridge.mapToHistoryFrom(_userservice.getHistory(userId)));
        }

        [HttpPut("{userId}/history/[action]")]
        public async Task<ActionResult<APIReturnObject>> updateHistory(int userId, [FromBody] HistoryEntity history)
        {
            return await Task.FromResult(_returnBridge.mapToAPIReturnObjectFrom(_userservice.updateHistory(userId, history)));
        }
    }
}
