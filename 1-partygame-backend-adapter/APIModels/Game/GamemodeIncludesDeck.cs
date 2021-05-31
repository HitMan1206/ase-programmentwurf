using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Game
{
    public class GamemodeIncludesDeck
    {

        private GamemodeModel gamemode;
        private Carddecks.Carddeck deck;

        public GamemodeIncludesDeck(GamemodeModel gamemode, Carddecks.Carddeck deck)
        {
            this.gamemode = gamemode;
            this.deck = deck;
        }

        public GamemodeModel Gamemode { get; set; }

        public Carddecks.Carddeck Deck { get; set; }
    }
}
