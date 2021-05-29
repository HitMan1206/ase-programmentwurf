using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Game
{
    public class GamemodeIncludesDeck
    {

        private long id;
        private GamemodeModel gamemode;
        private Carddecks.Carddeck deck;

        public GamemodeIncludesDeck(long id, GamemodeModel gamemode, Carddecks.Carddeck deck)
        {
            this.id = id;
            this.gamemode = gamemode;
            this.deck = deck;
        }

        public long Id { get; set; }

        public GamemodeModel Gamemode { get; set; }

        public Carddecks.Carddeck Deck { get; set; }
    }
}
