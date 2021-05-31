using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Game
{
    public class GameModel
    {

        private int id;
        private string name;
        private int actualPlayerId;
        private int statusId;
        private int gamemodeId;
        private int actualCardId;
        private double executionOfTaskRating;
        private int numberOfExecutionOfTaskRatings;

        public GameModel(int id, string name, int actualPlayerId, int statusId, int gamemodeId, int actualCardId, double executionOfTaskRating, int numberOfExecutionOfTaskRatings)
        {
            this.id = id;
            this.name = name;
            this.actualPlayerId = actualPlayerId;
            this.statusId = statusId;
            this.gamemodeId = gamemodeId;
            this.actualCardId = actualCardId;
            this.executionOfTaskRating = executionOfTaskRating;
            this.numberOfExecutionOfTaskRatings = numberOfExecutionOfTaskRatings;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int ActualPlayerId { get; set; }

        public int StatusId { get; set; }

        public int GamemodeId { get; set; }

        public int ActualCardId { get; set; }

        public double ExecutionOfTaskRating { get; set; }

        public int NumberOfExecutionOfTaskRatings { get; set; }
    }
}
