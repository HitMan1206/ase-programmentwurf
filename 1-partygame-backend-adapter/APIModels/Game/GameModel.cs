using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Game
{
    public class GameModel
    {

        private long id;
        private string name;
        private User.UserModel actualPlayer;
        private Gamestatus status;
        private GamemodeModel gamemode;
        private Carddecks.Taskcard actualCard;
        private double executionOfTaskRating;
        private int numberOfExecutionOfTaskRatings;

        public GameModel(long id, string name, User.UserModel actualPlayer, Gamestatus status, GamemodeModel gamemode, Carddecks.Taskcard actualCard, double executionOfTaskRating, int numberOfExecutionOfTaskRatings)
        {
            this.id = id;
            this.name = name;
            this.actualPlayer = actualPlayer;
            this.status = status;
            this.gamemode = gamemode;
            this.actualCard = actualCard;
            this.executionOfTaskRating = executionOfTaskRating;
            this.numberOfExecutionOfTaskRatings = numberOfExecutionOfTaskRatings;
        }
        public long Id { get; set; }

        public string Name { get; set; }

        public User.UserModel ActualPlayer { get; set; }

        public Gamestatus Status { get; set; }

        public GamemodeModel Gamemode { get; set; }

        public Carddecks.Taskcard ActualCard { get; set; }

        public double ExecutionOfTaskRating { get; set; }

        public int NumberOfExecutionOfTaskRatings { get; set; }
    }
}
