﻿using _1_partygame_backend_adapter.APIModels.Friends;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.Mappings.FriendMappings
{
    public class FriendBridge
    {

        public FriendBridge()
        {
        }

        public Friend mapToFriendFrom(FriendEntity friend)
        {
            UserMappings.UserBridge a = new UserMappings.UserBridge();

            return new Friend(a.mapToUserFrom(friend.getOther()), a.mapToUserFrom(friend.getMe()));
        }

        public FriendEntity mapToFriendEntityFrom(Friend friend)
        {
            UserMappings.UserBridge a = new UserMappings.UserBridge();

            return new FriendEntity(a.mapToUserEntityFrom(friend.Other), a.mapToUserEntityFrom(friend.Me));
        }

    }
}
