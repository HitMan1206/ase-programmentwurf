using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Game
{
    [Keyless]
    public class Player
    {
        private int spielerId;
        private int gameId;

        public Player(int spielerId, int gameId)
        {
            this.spielerId = spielerId;
            this.gameId = gameId;
        }

        public int SpielerId { get; set; }

        public int GameId { get; set; }
    }
}
