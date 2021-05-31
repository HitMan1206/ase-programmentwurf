using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Game
{
    [Keyless]
    public class GameHasDeck
    {
        private int gameId;
        private int deckId;

        public GameHasDeck(int gameId, int deckId)
        {
            this.gameId = gameId;
            this.deckId = deckId;
        }
        public int GameId { get; set; }

        public int DeckId { get; set; }
    }
}
