using _1_partygame_backend_adapter.APIModels;
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

        public APIControllerUserserviceHistory(Userservice service)
        {
            _userservice = service;

            _userBridge = new UserBridge();
            _returnBridge = new ReturnObjectBridge();
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
    }
}
