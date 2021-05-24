using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Entities.AggregateEntities
{
    public class PlayerEntity
    {
        private readonly GameEntity gameEntity;
        private readonly UserEntity userEntity;

        public PlayerEntity(GameEntity gameEntity, UserEntity userEntity)
        {
            this.gameEntity = gameEntity;
            this.userEntity = userEntity;
        }

        public int getGameId()
        {
            return gameEntity.getId();
        }

        public int getUserId()
        {
            return userEntity.getId();
        }
    }
}
