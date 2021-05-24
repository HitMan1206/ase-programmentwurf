using _3_partygame_backend_domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.AggregateEntities
{
    public class GameHasDeckEntity
    {
        private readonly GameEntity gameEntity;
        private readonly CarddeckEntity carddeckEntity;

        public GameHasDeckEntity(GameEntity gameEntity, CarddeckEntity carddeckEntity)
        {
            this.gameEntity = gameEntity;
            this.carddeckEntity = carddeckEntity;
        }

        public int getGameId()
        {
            return gameEntity.getId();
        }

        public int getDeckId()
        {
            return carddeckEntity.getId();
        }

    }
}
