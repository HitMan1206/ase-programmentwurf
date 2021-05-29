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
        private readonly int id;
        private readonly Gamemode gamemode;
        private readonly CarddeckEntity carddeckEntity;

        public GamemodeIncludesDeckEntity(int id, Gamemode gamemode, CarddeckEntity carddeckEntity)
        {
            this.id = id;
            this.gamemode = gamemode;
            this.carddeckEntity = carddeckEntity;
        }

        public int getId()
        {
            return id;
        }

        public Gamemode getGamemode()
        {
            return gamemode;
        }

        public int getGamemodeId()
        {
            return gamemode.getId();
        }

        public CarddeckEntity getDeck()
        {
            return carddeckEntity;
        }

        public int getDeckId()
        {
            return carddeckEntity.getId();
        }
    }
}
