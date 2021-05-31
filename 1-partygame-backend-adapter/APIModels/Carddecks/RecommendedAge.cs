using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Carddecks
{
    public class RecommendedAge
    {

        private int id;
        private string altersbereich;
        private int mindestalter;

        public RecommendedAge(int id, string altersbereich, int mindestalter)
        {
            this.id = id;
            this.altersbereich = altersbereich;
            this.mindestalter = mindestalter;
        }

        public int Id { get; set; }

        public string Altersbereich { get; set; }

        public int Mindestalter { get; set; }
    }
}
