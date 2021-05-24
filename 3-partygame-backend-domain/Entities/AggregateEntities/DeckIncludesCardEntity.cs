using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.AggregateEntities
{
    public class DeckIncludesCardEntity
    {
        private readonly CarddeckEntity carddeckEntity;
        private readonly TaskCard taskcard;

        public DeckIncludesCardEntity(CarddeckEntity carddeckEntity, TaskCard taskcard)
        {
            this.carddeckEntity = carddeckEntity;
            this.taskcard = taskcard;
        }

        public int getDeckId()
        {
            return carddeckEntity.getId();
        }

        public int getCardId()
        {
            return taskcard.getId();
        }
    }
}
