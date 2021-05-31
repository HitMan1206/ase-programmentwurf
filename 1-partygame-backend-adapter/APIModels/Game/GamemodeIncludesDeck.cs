using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Game
{
    [Keyless]
    public class GamemodeIncludesDeck
    {

        private int gamemodeId;
        private int deckId;

        public GamemodeIncludesDeck(int gamemodeId, int deckId)
        {
            this.gamemodeId = gamemodeId;
            this.deckId = deckId;
        }

        public int GamemodeId { get; set; }

        public int DeckId { get; set; }
    }
}
