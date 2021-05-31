using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Carddecks
{
    [Keyless]
    public class DeckIncludesCard
    {

        private int deckId;
        private int cardId;

        public DeckIncludesCard(int deckId, int cardId)
        {
            this.deckId = deckId;
            this.cardId = cardId;
        }

        public int DeckId { get; set; }

        public int CardId { get; set; }
    }
}
