using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Game
{
    public class Gamestatus
    {

        private long id;
        private string name;

        public Gamestatus(long id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}
