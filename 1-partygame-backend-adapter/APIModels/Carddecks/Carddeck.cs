using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Carddecks
{
    public class Carddeck
    {

        private long id;
        private Carddeckgenre genre;
        private string name;
        private double rating;
        private int gamesPlayed;
        private int numberOfRatings;

        public Carddeck(long id, Carddeckgenre genre, string name, double rating, int gamesPlayed, int numberOfRatings)
        {
            this.id = id;
            this.genre = genre;
            this.name = name;
            this.rating = rating;
            this.gamesPlayed = gamesPlayed;
            this.numberOfRatings = numberOfRatings;
        }

        public long Id { get; set; }

        public Carddeckgenre Genre { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public int GamesPlayed { get; set; }

        public int NumberOfRatings { get; set; }
    }
}
