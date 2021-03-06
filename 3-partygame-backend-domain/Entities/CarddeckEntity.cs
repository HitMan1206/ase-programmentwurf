using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Entities
{
    public class CarddeckEntity
    {

        private readonly int id;
        private readonly String name;
        private readonly int genre;
        private double rating = 0.0;
        private int gamesPlayedWith = 0;
        private int numberOfRatings = 0;


        public CarddeckEntity(int id, String name, int genre)
        {
            if (id < 0) throw new ArgumentException("Id must be >= 0.");
            this.id = id;
            if (name.Length < 1) throw new ArgumentException("Name length must be > 1");
            this.name = name;
            if (genre == null) throw new ArgumentException("Deckgenre cant be null.");
            this.genre = genre;
        }


        public int getId()
        {
            return id;
        }

        public String getName()
        {
            return name;
        }

        public int getGenre()
        {
            return genre;
        }

        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public int GamesPlayedWith
        {
            get { return gamesPlayedWith; }
            set { gamesPlayedWith = value; }
        }

        public int NumberOfRatings
        {
            get { return numberOfRatings; }
            set { numberOfRatings = value; }
        }

    }
}
