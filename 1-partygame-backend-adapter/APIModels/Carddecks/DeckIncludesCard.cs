using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Carddecks
{
    public class DeckIncludesCard
    {

        private long id;
        private Carddeck deck;
        private Taskcard card;

        public DeckIncludesCard(long id, Carddeck deck, Taskcard card)
        {
            this.id = id;
            this.deck = deck;
            this.card = card;
        }

        public long Id { get; set; }

        public Carddeck Deck { get; set; }

        public Taskcard Card { get; set; }
    }
}
