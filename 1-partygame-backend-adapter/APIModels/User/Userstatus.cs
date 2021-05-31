using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.User
{
    public class Userstatus
    {

        private int id;
        private string name;

        public Userstatus(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
