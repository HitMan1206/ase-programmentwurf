using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Entities
{
    public class GameEntity
    {

        private readonly int id;
        private String name;
        private UserEntity actualPlayingUser;
        private Status status;
        private Gamemode gamemode;

        public GameEntity(int id, String name) {

            if (id < 0) throw new ArgumentException("Id must be >= 0.");
            this.id = id;
            if (name.Length < 1) throw new ArgumentException("Name length must be > 1.");
            this.name = name;
        }

        public int getId()
        {
            return id;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public UserEntity ActualPlayingUser
        {
            get { return actualPlayingUser; }
            set { actualPlayingUser = value; }
        }

        public Status Status
        {
            get { return status; }
            set { status = value; }
        }

        public Gamemode Gamemode
        {
            get { return gamemode; }
            set { gamemode = value; }
        }
    }
}
