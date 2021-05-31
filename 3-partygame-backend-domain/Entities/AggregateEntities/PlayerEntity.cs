using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Entities.AggregateEntities
{
    public class PlayerEntity
    {
        private readonly int gameEntityId;
        private readonly int userEntityId;

        public PlayerEntity(int gameEntityId, int userEntityId)
        {
            this.gameEntityId = gameEntityId;
            this.userEntityId = userEntityId;
        }

        public int getGameId()
        {
            return gameEntityId;
        }

        public int getUserId()
        {
            return userEntityId;
        }
    }
}
