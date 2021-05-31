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
        private int id;
        private int playedGames;
        private int numberOfPenalties;
        private int userId;

        public HistoryModel(int id, int playedGames, int numberOfPenalties, int userId)
        {
            this.id = id;
            this.playedGames = playedGames;
            this.numberOfPenalties = numberOfPenalties;
            this.userId = userId;
        }

        public int Id { get; set; }

        public int PlayedGames { get; set; }

        public int NumberOfPenalties { get; set; }

        
        public int UserId { get; set; }
    }
}
