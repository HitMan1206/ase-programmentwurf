using _3_partygame_backend_domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Repositories
{
    interface HistoryRepository
    {
        HistoryEntity getHistoryFromUser(UserEntity user);

        bool update(HistoryEntity history);

        bool create(UserEntity user);
    }
}
