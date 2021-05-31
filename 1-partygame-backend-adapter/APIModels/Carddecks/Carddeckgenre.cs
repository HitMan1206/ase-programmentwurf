using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Carddecks
{
    public class Carddeckgenre
    {

        private int id;
        private string name;
        private int recommendedAgeId;

        public Carddeckgenre(int id, string name, int recommendedAgeId)
        {
            this.id = id;
            this.name = name;
            this.recommendedAgeId = recommendedAgeId;
        }


        public int Id { get; set; }

        public string Name { get; set; }

        public int RecommendedAgeId { get; set; }

    }
}
