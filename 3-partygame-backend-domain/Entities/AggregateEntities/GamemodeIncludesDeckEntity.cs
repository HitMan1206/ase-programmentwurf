using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.AggregateEntities
{
    public class GamemodeIncludesDeckEntity
    {
        private readonly Gamemode gamemode;
        private readonly CarddeckEntity carddeckEntity;

        public GamemodeIncludesDeckEntity(Gamemode gamemode, CarddeckEntity carddeckEntity)
        {
            this.gamemode = gamemode;
            this.carddeckEntity = carddeckEntity;
        }

        public int getGamemodeId()
        {
            return gamemode.getId();
        }

        public int getDeckId()
        {
            return carddeckEntity.getId();
        }
    }
}
