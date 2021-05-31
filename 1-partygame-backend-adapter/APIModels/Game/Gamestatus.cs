using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Game
{
    public class Gamestatus
    {

        private int id;
        private string name;

        public Gamestatus(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
