using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Entities
{
    public class HistoryEntity
    {

        private readonly int id;
        private readonly UserEntity user;
        private int playedGames;
        private int numberOfPenalties;

        public HistoryEntity(int id, UserEntity user) {

            if (id < 0) throw new ArgumentException("Id must be >= 0.");
            this.id = id;
            if (user.HasHistory) throw new ArgumentException("History for User already exist.");
            this.user = user;
        }

        public int Id
        {
            get { return id; }
        }

        public UserEntity User
        {
            get { return user; }
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
