using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Entities
{
    public class HistoryEntity
    {

        private readonly int id;
        private readonly int userId;
        private int playedGames;
        private int numberOfPenalties;

        public HistoryEntity(int id, int userId) {

            if (id < 0) throw new ArgumentException("Id must be >= 0.");
            this.id = id;
            this.userId = userId;
        }

        public int Id
        {
            get { return id; }
        }

        public int UserId
        {
            get { return userId; }
        }

        public int PlayedGames
        {
            get { return playedGames; }
            set 
            {
                if (playedGames >= value) throw new ArgumentException("New value has to be greater than the Old.");
                playedGames = value;
            }
        }

        public int NumberOfPenalties
        {
            get { return numberOfPenalties; }
            set
            {
                if (numberOfPenalties >= value) throw new ArgumentException("New value has to be greater than the Old.");
                numberOfPenalties = value;
            }
        }


    }
}
