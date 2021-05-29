using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Carddecks
{
    public class Carddeckgenre
    {

        private long id;
        private string name;
        private RecommendedAge recommendedAge;

        public Carddeckgenre(long id, string name, RecommendedAge recommendedAge)
        {
            this.id = id;
            this.name = name;
            this.recommendedAge = recommendedAge;
        }


        public long Id { get; set; }

        public string Name { get; set; }

        public RecommendedAge RecommendedAge { get; set; }

    }
}
