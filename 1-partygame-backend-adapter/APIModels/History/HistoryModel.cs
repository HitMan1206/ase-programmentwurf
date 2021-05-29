using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using _1_partygame_backend_adapter.APIModels.User;

namespace _1_partygame_backend_adapter.APIModels.History
{
    public class HistoryModel
    {
        private long id;
        private int playedGames;
        private int numberOfPenalties;
        private User.UserModel user;

        public HistoryModel(long id, int playedGames, int numberOfPenalties, User.UserModel user)
        {
            this.id = id;
            this.playedGames = playedGames;
            this.numberOfPenalties = numberOfPenalties;
            this.user = user;
        }

        public long Id { get; set; }

        public int PlayedGames { get; set; }

        public int NumberOfPenalties { get; set; }

        
        public User.UserModel User { get; set; }
    }
}
