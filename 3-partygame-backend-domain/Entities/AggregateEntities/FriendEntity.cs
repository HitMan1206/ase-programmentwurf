using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Entities.AggregateEntities
{
    public class FriendEntity
    {
        private readonly UserEntity friendTo;
        private readonly UserEntity friendFrom;

        public FriendEntity(UserEntity friendTo, UserEntity friendFrom)
        {
            this.friendFrom = friendFrom;
            this.friendTo = friendTo;
        }

        public int getFriendToId()
        {
            return friendTo.getId();
        }

        public int getFriendFromId()
        {
            return friendFrom.getId();
        }
    }
}
