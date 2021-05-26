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
        private readonly Carddeckgenre genre;
        private double rating;
        private int gamesPlayedWith;
        private int numberOfRatings;


        public CarddeckEntity(int id, String name, Carddeckgenre genre)
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

        public Carddeckgenre getGenre()
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
