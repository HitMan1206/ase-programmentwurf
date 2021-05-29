using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Game
{
    public class GameHasDeck
    {
        private GameModel game;
        private Carddecks.Carddeck deck;

        public GameHasDeck(GameModel game, Carddecks.Carddeck deck)
        {
            this.game = game;
            this.deck = deck;
        }
        public GameModel Game { get; set; }

        public Carddecks.Carddeck Deck { get; set; }
    }
}
