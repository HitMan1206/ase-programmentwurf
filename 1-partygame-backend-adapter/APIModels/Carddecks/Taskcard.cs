using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Carddecks
{
    public class Taskcard
    {

        private long id;
        private string name;
        private string task;
        private string penalty;

        public Taskcard(long id, string name, string task, string penalty)
        {
            this.id = id;
            this.name = name;
            this.task = task;
            this.penalty = penalty;
        }


        public long Id { get; set; }

        public string Name { get; set; }

        public string Task { get; set; }

        public string Penalty { get; set; }
    }
}
