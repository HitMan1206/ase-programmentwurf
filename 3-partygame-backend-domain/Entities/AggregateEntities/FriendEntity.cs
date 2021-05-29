using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Entities.AggregateEntities
{
    public class FriendEntity
    {
        private readonly UserEntity other;
        private readonly UserEntity me;

        public FriendEntity(UserEntity other, UserEntity me)
        {
            this.other = other;
            this.me = me;
        }

        public UserEntity getOther()
        {
            return other;
        }

        public UserEntity getMe()
        {
            return me;
        }

        public int getOtherId()
        {
            return other.getId();
        }

        public int getMyId()
        {
            return me.getId();
        }

        public string getOtherEmail()
        {
            return other.getEmail();
        }

        public string getMyEmail()
        {
            return me.getEmail();
        }
    }
}
