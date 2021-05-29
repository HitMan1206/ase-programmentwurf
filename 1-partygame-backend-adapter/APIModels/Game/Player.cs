using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Game
{
    public class Player
    {
        private long id;
        private User.UserModel spieler;
        private GameModel game;

        public Player(int id, User.UserModel spieler, GameModel game)
        {
            this.id = id;
            this.spieler = spieler;
            this.game = game;
        }

        public long Id { get; set; }

        public User.UserModel Spieler { get; set; }

        public GameModel Game { get; set; }
    }
}
