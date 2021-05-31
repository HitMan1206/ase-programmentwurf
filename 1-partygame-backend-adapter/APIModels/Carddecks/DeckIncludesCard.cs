using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Carddecks
{
    public class DeckIncludesCard
    {

        private Carddeck deck;
        private Taskcard card;

        public DeckIncludesCard(Carddeck deck, Taskcard card)
        {
            this.deck = deck;
            this.card = card;
        }

        public Carddeck Deck { get; set; }

        public Taskcard Card { get; set; }
    }
}
