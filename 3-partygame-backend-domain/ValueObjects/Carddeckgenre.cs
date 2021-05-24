using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.ValueObjects
{
    public sealed class Carddeckgenre
    {

        private readonly int id;
        private readonly String name;
        private readonly RecommendedAge age;

        public Carddeckgenre(int id, String name, RecommendedAge age)
        {
            if (id < 0) throw new ArgumentException("Id must be >= 0.");
            this.id = id;
            if (name.Length < 1) throw new ArgumentException("Name length must be >= 1.");
            this.name = name;
            this.age = age;
        }

        public int getId()
        {
            return id;
        }

        public String getName()
        {
            return name;
        }

        public RecommendedAge getAge()
        {
            return age;
        }

    }
}
