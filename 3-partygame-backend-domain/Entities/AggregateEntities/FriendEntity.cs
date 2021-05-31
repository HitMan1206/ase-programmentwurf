using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Entities.AggregateEntities
{
    public class FriendEntity
    {
        private readonly int otherId;
        private readonly int meId;

        public FriendEntity(int otherId, int meId)
        {
            this.otherId = otherId;
            this.meId = meId;
        }

        public int getOtherId()
        {
            return otherId;
        }

        public int getMyId()
        {
            return meId;
        }
    }
}
