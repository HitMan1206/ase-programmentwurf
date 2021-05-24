using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.ValueObjects
{
    public class Gamemode
    {
        private readonly int id;
        private readonly String name;

        public Gamemode(int id, String name)
        {
            if (id < 0) throw new ArgumentException("Id must be >= 0.");
            this.id = id;
            if (name.Length < 1) throw new ArgumentException("Name length must be >= 1.");
            this.name = name;
        }

        public int getId()
        {
            return id;
        }

        public String getName()
        {
            return name;
        }
    }
}
