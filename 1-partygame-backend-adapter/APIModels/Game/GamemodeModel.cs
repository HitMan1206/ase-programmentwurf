using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Game
{
    public class GamemodeModel
    {

        private int id;
        private string name;

        public GamemodeModel(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
