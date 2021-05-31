using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.APIModels.Friends
{
    [Keyless]
    public class Friend
    {

        private int otherId;
        private int meId;

        public Friend(int otherId, int meId)
        {
            this.otherId = otherId;
            this.meId = meId;
        }

        public int OtherId { get; set; }

        public int MeId { get; set; }
    }
}
