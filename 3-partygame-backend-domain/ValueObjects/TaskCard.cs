using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.ValueObjects
{
    public sealed class TaskCard
    {
        private readonly int id;
        private readonly String task;
        private readonly String penalty;
        private readonly String name;

        public TaskCard(int id, String task, String penalty, String name)
        {
            if (id <= 0) throw new ArgumentException("Id must be >= 0.");
            this.id = id;
            if (task.Length < 1) throw new ArgumentException("Task length must be >= 1.");
            this.task = task;
            if (penalty.Length < 1) throw new ArgumentException("Penalty length must be >= 1.");
            this.penalty = penalty;
            this.name = name;
        }

        public int getId()
        {
            return id;
        }

        public String getTask()
        {
            return task;
        }

        public String getPenalty()
        {
            return penalty;
        }

        public String getName()
        {
            return name;
        }
    }
}
